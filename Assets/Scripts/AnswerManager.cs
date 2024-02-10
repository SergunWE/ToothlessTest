using System.Collections.Generic;
using UnityEngine;

namespace ToothlessTestSpace
{
    public class AnswerManager : MonoBehaviour
    {
        [SerializeField] private List<AnswerButton> answerButtons;

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
    }
}