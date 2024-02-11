using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;
using Random = UnityEngine.Random;

namespace ToothlessTestSpace
{
    public class ResultManager : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField] private RawImage rawImage;
#endif
        [SerializeField, Space] private GameObject uiRoot;
        [SerializeField] private VideoPlayer videoPlayer;

        [SerializeField, Space] private string urlPrefix;
        [SerializeField] private string urlPostfix;

        [SerializeField, Space] private UnityEvent videoLoaded;
        
        [SerializeField, Space] private List<ResultDataSo> results;

        private void Awake()
        {
            InitResults();
        }
        
        private void InitResults()
        {
            uiRoot.SetActive(false);
            
            foreach (var result in results)
            {
                result.Reset();
            }
        }

        public void OnQuestionEnded()
        {
            var result = GetResult();

#if UNITY_EDITOR
            rawImage.texture = result.DebugSprite.texture;
            return;
#endif
            videoPlayer.url = urlPrefix + result.VideoFileName + urlPostfix;
            videoPlayer.prepareCompleted += OnPrepareCompleted;
            videoPlayer.Prepare();
        }

        private void OnPrepareCompleted(VideoPlayer source)
        {
            videoPlayer.prepareCompleted -= OnPrepareCompleted;
            videoPlayer.Play();
            videoLoaded?.Invoke();
        }

        private ResultDataSo GetResult()
        {
            int maxValue = results.Max(x => x.Score);
            var maxItems = results.Where(x => x.Score == maxValue).ToList();
            return maxItems[Random.Range(0, maxItems.Count)];
        }

    }
}