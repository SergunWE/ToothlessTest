using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace ToothlessTestSpace
{
    public class Music : MonoBehaviour
    {
        [SerializeField, Multiline] private string musicUrl;
        [SerializeField] private AudioSource audioSource;

        private void Awake()
        {
            StartCoroutine(LoadMusic());
        }

        private IEnumerator LoadMusic()
        {
            using UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(musicUrl, AudioType.MPEG);
            DownloadHandlerAudioClip dHA = new DownloadHandlerAudioClip(string.Empty, AudioType.MPEG);
            dHA.streamAudio = true;
            www.downloadHandler = dHA;
            www.SendWebRequest();
            while (www.downloadProgress < 1) {
                Debug.Log(www.downloadProgress);
                yield return new WaitForSeconds(.1f);
            }
            if (www.responseCode != 200 || www.result == UnityWebRequest.Result.ConnectionError) {
                Debug.Log("error");
            } else {
                audioSource.clip = DownloadHandlerAudioClip.GetContent(www);
                Debug.Log("Start audio play");
                audioSource.Play();
            }
        }
    }
}