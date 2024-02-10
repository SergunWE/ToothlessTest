using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ToothlessTestSpace
{
    public class AnswerManager : MonoBehaviour
    {
        [SerializeField] private UnityEvent answerGiven;
        
        [SerializeField] private List<AnswerButton> answerButtons;

        private void OnEnable()
        {
            foreach (var button in answerButtons)
            {
                button.ButtonClicked += OnAnswerClicked;
            }
        }

        private void OnDisable()
        {
            foreach (var button in answerButtons)
            {
                button.ButtonClicked -= OnAnswerClicked;
            }
        }

        public void SetAnswers(QuestionDataSo questionDataSo)
        {
            for (int i = 0; i < answerButtons.Count && i < questionDataSo.AnswersData.Count; i++)
            {
                answerButtons[i].SetAnswer(questionDataSo.AnswersData[i]);
            }
        }

        public void OnQuestionInitialized()
        {
            foreach (var answerButton in answerButtons)
            {
                answerButton.SetAnswer(null);
            }
        }

        public void OnQuestionEnded()
        {
            foreach (var answerButton in answerButtons)
            {
                answerButton.SetAnswer(null);
            }
        }

        private void OnAnswerClicked(AnswerData answer)
        {
            answer.ApplyAnswer();
            answerGiven?.Invoke();
        }
    }
}