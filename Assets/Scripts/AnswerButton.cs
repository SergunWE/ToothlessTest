using System;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

namespace ToothlessTestSpace
{
    public class AnswerButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private LocalizeStringEvent stringEvent;

        public event Action<AnswerData> ButtonClicked;

        private AnswerData _currentAnswerData;

        private void Awake()
        {
            button.onClick.AddListener(OnButtonClicked);
        }

        public void SetAnswer(AnswerData answerData)
        {
            if(answerData == null) return;
            _currentAnswerData = answerData;
            stringEvent.StringReference = answerData.AnswerText;
        }
        
        private void OnButtonClicked()
        {
            ButtonClicked?.Invoke(_currentAnswerData);
        }

        private void HideButton()
        {
            
        }

        private void ShowButton()
        {
            
        }
    }
}