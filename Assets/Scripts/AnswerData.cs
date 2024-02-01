using System;
using UnityEngine;

namespace ToothlessTestSpace
{
    [Serializable]
    public class AnswerData
    {
        [field:SerializeField] public ResultDataSo ResultData { get; private set; }
        [field:SerializeField] public int Score { get; private set; }
    }
}