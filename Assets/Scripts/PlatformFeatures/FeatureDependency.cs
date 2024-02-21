using ToothlessTestSpace.PlatformFeatures.AdFeatures;

namespace ToothlessTestSpace.PlatformFeatures
{
    public static class FeatureDependency
    {
        private static IAdFeature _adFeature;

        public static IAdFeature AdFeature => _adFeature ??= new UnityAdFeature();

        public static void Configure(IAdFeature adFeature)
        {
            _adFeature = adFeature;
        }
    }
}