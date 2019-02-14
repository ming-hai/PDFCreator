﻿using pdfforge.PDFCreator.Conversion.Settings.GroupPolicies;
using pdfforge.PDFCreator.Utilities;
using System;
using SystemInterface.Microsoft.Win32;

namespace pdfforge.PDFCreator.Core.SettingsManagement
{
    public interface IWelcomeSettingsHelper
    {
        bool CheckIfRequiredAndSetCurrentVersion();

        void SetCurrentApplicationVersionAsWelcomeVersionInRegistry();
    }

    public class WelcomeSettingsHelper : IWelcomeSettingsHelper
    {
        public const string RegistryKeyForWelcomeSettings = @"HKEY_CURRENT_USER\Software\pdfforge\PDFCreator";
        public const string RegistryValueForWelcomeVersion = @"LatestWelcomeVersion";

        private readonly IRegistry _registryWrap;
        private readonly IVersionHelper _versionHelper;
        private readonly IGpoSettings _gpoSettings;

        public WelcomeSettingsHelper(IRegistry registryWrap, IVersionHelper versionHelper, IGpoSettings gpoSettings)
        {
            _registryWrap = registryWrap;
            _versionHelper = versionHelper;
            _gpoSettings = gpoSettings;
        }

        public bool CheckIfRequiredAndSetCurrentVersion()
        {
            var currentApplicationVersion = _versionHelper.FormatWithBuildNumber();
            var welcomeVersionFromRegistry = GetWelcomeVersionFromRegistry();

            if (currentApplicationVersion.Equals(welcomeVersionFromRegistry, StringComparison.OrdinalIgnoreCase))
                return false;

            SetCurrentApplicationVersionAsWelcomeVersionInRegistry();
            return true;
        }

        public void SetCurrentApplicationVersionAsWelcomeVersionInRegistry()
        {
            var currentApplicationVersion = _versionHelper.FormatWithBuildNumber();
            _registryWrap.SetValue(RegistryKeyForWelcomeSettings, RegistryValueForWelcomeVersion, currentApplicationVersion);
        }

        private string GetWelcomeVersionFromRegistry()
        {
            var value = _registryWrap.GetValue(RegistryKeyForWelcomeSettings, RegistryValueForWelcomeVersion, null);
            if (value == null)
                return "";
            return value.ToString();
        }
    }
}
