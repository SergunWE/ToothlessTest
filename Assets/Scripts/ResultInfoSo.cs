using UnityEngine;

namespace ToothlessTest
{
    [CreateAssetMenu(menuName = "ResultInfoSo")]
    public class ResultInfoSo : ScriptableObject
    {
#if UNITY_EDITOR
        [field:SerializeField] public Sprite DebugSprite { get; private set; }
#endif
        [field:SerializeField] public int Score { get; set; }
        [field:SerializeField] public string VideoFileName { get; private set; }
    }
}