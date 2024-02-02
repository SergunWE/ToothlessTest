using UnityEngine;
using UnityEngine.Localization;

namespace ToothlessTestSpace
{
    [CreateAssetMenu(menuName = "ResultDataSo", fileName = "ResultData")]
    public class ResultDataSo : ScriptableObject
    {
#if UNITY_EDITOR
        [field:SerializeField] public Sprite DebugSprite { get; private set; }
#endif
        [field:SerializeField] public int Score { get; set; }
        [field:SerializeField] public LocalizedString Name { get; private set; }
        [field:SerializeField] public string VideoFileName { get; private set; }

        public void Reset()
        {
            Score = 0;
        }
    }
}