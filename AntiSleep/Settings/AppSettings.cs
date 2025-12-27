using System.Text.Json;

namespace AntiSleep.Settings
{
    /// <summary>
    /// Verwaltet die Anwendungseinstellungen
    /// </summary>
    public class AppSettings
    {
        private static readonly string SettingsPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "AntiSleep",
            "settings.json"
        );

        /// <summary>
        /// Intervall für Mausbewegung in Millisekunden
        /// </summary>
        public int MoveInterval { get; set; } = 1000;

        /// <summary>
        /// Ob die Mausbewegung sichtbar sein soll
        /// </summary>
        public bool MouseMoveVisible { get; set; } = true;

        /// <summary>
        /// Entfernung der Mausbewegung in Pixeln
        /// </summary>
        public int MoveDistance { get; set; } = 1;

        /// <summary>
        /// Lädt die Einstellungen aus der JSON-Datei
        /// </summary>
        public static AppSettings Load()
        {
            try
            {
                if (File.Exists(SettingsPath))
                {
                    string json = File.ReadAllText(SettingsPath);
                    var settings = JsonSerializer.Deserialize<AppSettings>(json);
                    return settings ?? new AppSettings();
                }
            }
            catch (Exception ex)
            {
                // Bei Fehler Standard-Einstellungen zurückgeben
                System.Diagnostics.Debug.WriteLine($"Fehler beim Laden der Einstellungen: {ex.Message}");
            }

            return new AppSettings();
        }

        /// <summary>
        /// Speichert die aktuellen Einstellungen in die JSON-Datei
        /// </summary>
        public void Save()
        {
            try
            {
                // Verzeichnis erstellen, falls es nicht existiert
                string? directory = Path.GetDirectoryName(SettingsPath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Einstellungen als JSON speichern
                var options = new JsonSerializerOptions 
                { 
                    WriteIndented = true 
                };
                string json = JsonSerializer.Serialize(this, options);
                File.WriteAllText(SettingsPath, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Fehler beim Speichern der Einstellungen: {ex.Message}");
            }
        }
    }
}
