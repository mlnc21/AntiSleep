using System.Globalization;

namespace AntiSleep.Localization
{
    public static class LocalizationManager
    {
        private static readonly Dictionary<string, Dictionary<string, string>> Translations = new()
        {
            ["en"] = new Dictionary<string, string>
            {
                ["Activate"] = "Activate",
                ["Deactivate"] = "Deactivate",
                ["Exit"] = "Exit",
                ["Interval"] = "Interval (ms):",
                ["ModeActivated"] = "Anti-Sleep mode activated",
                ["ModeDeactivated"] = "Anti-Sleep mode deactivated",
                ["Open"] = "Open",
                ["ProgramInBackground"] = "Program running in background. Double-click to open.",
                ["ProgramStarted"] = "Program started. Click 'Activate' to start Anti-Sleep mode.",
                ["Settings"] = "Settings",
                ["StatusActive"] = "AntiSleep - Active",
                ["StatusInactive"] = "AntiSleep - Inactive",
                ["ToggleActivation"] = "Toggle Activation",
                ["VisibleMouseMovement"] = "Visible Mouse Movement"
            },
            ["de"] = new Dictionary<string, string>
            {
                ["Activate"] = "Aktivieren",
                ["Deactivate"] = "Deaktivieren",
                ["Exit"] = "Beenden",
                ["Interval"] = "Intervall (ms):",
                ["ModeActivated"] = "Anti-Sleep-Modus aktiviert",
                ["ModeDeactivated"] = "Anti-Sleep-Modus deaktiviert",
                ["Open"] = "Öffnen",
                ["ProgramInBackground"] = "Programm läuft im Hintergrund weiter. Doppelklick zum Öffnen.",
                ["ProgramStarted"] = "Programm gestartet. Klicken Sie auf 'Aktivieren', um den Anti-Sleep-Modus zu starten.",
                ["Settings"] = "Einstellungen",
                ["StatusActive"] = "AntiSleep - Aktiv",
                ["StatusInactive"] = "AntiSleep - Inaktiv",
                ["ToggleActivation"] = "Aktivierung umschalten",
                ["VisibleMouseMovement"] = "Sichtbare Mausbewegung"
            }
        };

        private static string CurrentLanguage { get; set; } = "en";

        static LocalizationManager()
        {
            // Automatisch Sprache basierend auf System setzen
            var culture = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            CurrentLanguage = Translations.ContainsKey(culture) ? culture : "en";
        }

        public static string Get(string key)
        {
            if (Translations.TryGetValue(CurrentLanguage, out var languageDict))
            {
                if (languageDict.TryGetValue(key, out var value))
                {
                    return value;
                }
            }
            
            // Fallback to English
            return Translations["en"].TryGetValue(key, out var fallback) ? fallback : key;
        }

        public static void SetLanguage(string languageCode)
        {
            if (Translations.ContainsKey(languageCode))
            {
                CurrentLanguage = languageCode;
            }
        }
    }
}
