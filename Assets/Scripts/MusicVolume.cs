using System;
using UnityEngine;
using UnityEngine.UI;

namespace ToothlessTestSpace
{
    public class MusicVolume : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private GameObject uiLine;

        private bool _enable = true;

        private void Start()
        {
            ChangeState();
        }

        private void OnEnable()
        {
            button.onClick.AddListener(Call);
        }
        
        private void OnDisable()
        {
            button.onClick.RemoveListener(Call);
        }

        private void Call()
        {
            _enable = !_enable;
            ChangeState();
        }

        private void ChangeState()
        {
            audioSource.mute = !_enable;
            uiLine.SetActive(!_enable);
        }
    }
}