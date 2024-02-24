using UnityEngine;
using UnityEngine.SceneManagement;

namespace ToothlessTestSpace.FeaturesConfigures
{
    public abstract class FeaturesConfigure : MonoBehaviour
    {
        [SerializeField] private bool forcedDisable;
        
        private void Start()
        {
#if !UNITY_EDITOR
            if(!forcedDisable)
            {
                RegisterFeatures();
            }
#endif
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        protected abstract void RegisterFeatures();
    }
}