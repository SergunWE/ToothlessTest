using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using YG;

namespace ToothlessTestSpace
{
    public class Language : MonoBehaviour
    {
        [SerializeField] private GameObject loadObj;
        
        private void Start()
        {
            loadObj.SetActive(true);
            StartCoroutine(LoadLanguage());
        }

        private IEnumerator LoadLanguage()
        {
            while (!LocalizationSettings.InitializationOperation.IsDone)
            {
                yield return new WaitForEndOfFrame();
            }
            
            var locale = LocalizationSettings.AvailableLocales.Locales.Find(x =>
                x.Identifier.Code.IndexOf(YandexGame.EnvironmentData.language, StringComparison.Ordinal) != -1);
            var localeIdentifier = locale == null ? new LocaleIdentifier(Application.systemLanguage): locale.Identifier;
            
            var newLocale = LocalizationSettings.AvailableLocales.GetLocale(localeIdentifier);
            LocalizationSettings.SelectedLocale = newLocale;
            loadObj.SetActive(false);
            YandexGame.GameReadyAPI();
        }
    }
}