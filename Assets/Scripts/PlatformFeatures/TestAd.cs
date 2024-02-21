using System;
using ToothlessTestSpace.PlatformFeatures.AdFeatures;
using UnityEngine;

namespace ToothlessTestSpace.PlatformFeatures
{
    public class TestAd : MonoBehaviour
    {
        private readonly IAdFeature _adFeature = FeatureDependency.AdFeature;

        private void Start()
        {
            _adFeature.ShowFullscreen();
        }
    }
}