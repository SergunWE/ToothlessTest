using ToothlessTestSpace.PlatformFeatures;
using ToothlessTestSpace.PlatformFeatures.AdFeatures;
using UnityEngine;
using YG;

namespace ToothlessTestSpace.FeaturesConfigures
{
    public class YandexGameFeaturesConfigure : FeaturesConfigure
    {
        [SerializeField] private GameObject yandexPrefab;

        protected override void RegisterFeatures()
        {
            var yandex = Instantiate(yandexPrefab).GetComponent<YandexGame>();
            var adFeature = new YandexAdFeature(yandex.infoYG);
            adFeature.InitCallbacks();
            FeatureDependency.Configure(adFeature);
        }
    }
}