using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

namespace ToothlessTestSpace
{
    [CreateAssetMenu(menuName = "QuestionDataSo", fileName = "QuestionData")]
    public class QuestionDataSo : ScriptableObject
    {
        [field:SerializeField] public LocalizedString Question { get; private set; }
        [field:SerializeField] public List<AnswerData> AnswersData { get; private set; }
    }
}