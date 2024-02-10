using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization.Components;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace ToothlessTestSpace
{
    public class QuestionManager : MonoBehaviour
    {
        [SerializeField] private LocalizeStringEvent stringEvent;
        
        [SerializeField] private UnityEvent questionInitialized;
        [SerializeField] private UnityEvent<QuestionDataSo> newQuestionSet;
        [SerializeField] private UnityEvent questionEnded;

        [SerializeField] private List<ResultDataSo> results;
        [SerializeField] private List<QuestionDataSo> questions;

        private readonly List<int> _queueQuestions = new();
        private QuestionDataSo _currentQuestion;
        private int _currentQuestionIndex;

        private void Awake()
        {
            InitQuestions();
            SetNewQuestion();
        }

        public void OnAnswerGiven()
        {
            SetNewQuestion();
        }

        private void InitQuestions()
        {
            _queueQuestions.Clear();
            int questionsCount = questions.Count;
            for (int i = 0; i < questionsCount; i++)
            {
                _queueQuestions.Add(i);
            }

            Shuffle(_queueQuestions);

            foreach (var result in results)
            {
                result.Reset();
            }

            _currentQuestionIndex = 0;
            questionInitialized?.Invoke();
        }

        private void SetNewQuestion()
        {
            if (_currentQuestionIndex >= _queueQuestions.Count)
            {
                questionEnded?.Invoke();
                return;
            }

            _currentQuestion = questions[_queueQuestions[_currentQuestionIndex]];
            stringEvent.StringReference = _currentQuestion.Question;
            newQuestionSet?.Invoke(_currentQuestion);
            _currentQuestionIndex++;
        }

        private static void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Range(0, n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }
    }
}