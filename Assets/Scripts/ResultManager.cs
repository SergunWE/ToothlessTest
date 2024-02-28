using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ToothlessTestSpace.PlatformFeatures;
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
        [SerializeField] private VideoPlayer videoPlayer;
        
        [SerializeField] private string urlPostfix;

        [SerializeField, Space] private UnityEvent videoLoaded;
        
        [SerializeField, Space] private List<ResultDataSo> results;

        private void Awake()
        {
            InitResults();
        }
        
        public void InitResults()
        {
            foreach (var result in results)
            {
                result.Reset();
            }
        }

        public void OnQuestionEnded()
        {
            var result = GetResult();
            
            videoPlayer.url = Path.Combine(Application.streamingAssetsPath,result.VideoFileName + urlPostfix);
            videoPlayer.prepareCompleted += OnPrepareCompleted;
            videoPlayer.Prepare();
        }

        private void OnPrepareCompleted(VideoPlayer source)
        {
            videoPlayer.prepareCompleted -= OnPrepareCompleted;
            videoPlayer.Play();
            StartCoroutine(ResultCoroutine());
        }

        private ResultDataSo GetResult()
        {
            int maxValue = results.Max(x => x.Score);
            var maxItems = results.Where(x => x.Score == maxValue).ToList();
            return maxItems[Random.Range(0, maxItems.Count)];
        }

        private IEnumerator ResultCoroutine()
        {
            yield return new WaitForSeconds(2);
            FeatureDependency.AdFeature.ShowFullscreen();
            videoLoaded?.Invoke();
        }

    }
}