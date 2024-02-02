using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

namespace ToothlessTestSpace
{
    [Serializable]
    public class AnswerData
    {
        [field:SerializeField] public LocalizedString AnswerText { get; private set; }
        [field:SerializeField] public List<AnswerScore> AnswerScore { get; private set; }
    }

    [Serializable]
    public class AnswerScore
    {
        [field:SerializeField] public ResultDataSo ResultData { get; private set; }
        [field:SerializeField] public int Score { get; private set; }
    }
}