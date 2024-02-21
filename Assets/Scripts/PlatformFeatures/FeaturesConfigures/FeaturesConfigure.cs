using UnityEngine;
using UnityEngine.SceneManagement;

namespace ToothlessTestSpace.FeaturesConfigures
{
    public abstract class FeaturesConfigure : MonoBehaviour
    {
        private void Start()
        {
#if !UNITY_EDITOR
            RegisterFeatures();
#endif
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        protected abstract void RegisterFeatures();
    }
}