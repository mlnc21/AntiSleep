
# AntiSleep

> **Verhindert zuverlässig, dass Windows in den Sperrbildschirm oder Standby wechselt.**  
Ideal für Präsentationen, Downloads, Builds, Video-Renderings oder lange Prozesse.
# AntiSleep - Optimierungen & Features
<img width="328" height="244" alt="image" src="https://github.com/user-attachments/assets/33975e43-088d-4e7f-bff8-060f4a200b62" />

## ✨ Fluent UI Design
Die Anwendung verwendet jetzt ein modernes Fluent UI Design:
- **Farben**: Microsoft Fluent UI Farbpalette
  - Primär (Aktivieren): `#0078D4` (Blau)
  - Warnung (Deaktivieren): `#C50F1F` (Rot)
  - Hintergrund: `#F3F3F3` (Hellgrau)
  - Karten/Panels: `#FFFFFF` (Weiß)
  - Text: `#202020` (Dunkelgrau)
- **Button-Styling**: Flat Design ohne Rahmen mit Hover-Effekt
- **Verbesserte Anordnung**: Größerer Button, besseres Spacing, professionelles Layout
- **Konsistente Farbgebung**: Alle UI-Elemente folgen den Fluent Design Richtlinien

## 🌍 Multi-Language Support
Die Anwendung erkennt automatisch die Systemsprache und passt die UI entsprechend an:
- **Deutsch (de)**: Vollständig übersetzt
- **Englisch (en)**: Standard-Fallback

### Unterstützte Sprachen
- Deutsch (wird automatisch bei deutschem Windows aktiviert)
- Englisch (Standard)

### Implementierung
- `LocalizationManager.cs`: Zentrale Verwaltung aller Übersetzungen
- Automatische Spracherkennung basierend auf `CultureInfo.CurrentUICulture`
- Einfach erweiterbar für neue Sprachen
- Alle UI-Texte, Benachrichtigungen und Kontextmenüs sind lokalisiert

## 📐 Verbessertes Layout
- **GroupBox "Settings"**: Enthält alle Einstellungen mit besserem Padding
- **Intervall-Einstellung**: Volle Breite für bessere Usability mit NumericUpDown-Control
- **Checkbox**: Optimale Positionierung unterhalb der Intervall-Einstellung
- **Aktivieren-Button**: Volle Breite, größer, prominenter platziert
- **Feste Fenstergröße**: Kein Maximieren-Button, konsistente Größe (400x300)

## 💾 Persistente Einstellungen
Die App speichert automatisch alle Benutzereinstellungen:
- **Speicherort**: `%AppData%\AntiSleep\settings.json`
- **Gespeicherte Werte**:
  - Intervall für Mausbewegung (in Millisekunden)
  - Sichtbare Mausbewegung (Checkbox-Status)
  - Bewegungsdistanz in Pixeln
- **Automatisches Speichern**: Einstellungen werden sofort bei jeder Änderung gespeichert
- **Automatisches Laden**: Beim Programmstart werden die letzten Einstellungen wiederhergestellt
- **Fehlerbehandlung**: Bei fehlenden oder beschädigten Settings werden Standardwerte verwendet

### Implementierung
- `AppSettings.cs`: Klasse für Einstellungsverwaltung
- JSON-basierte Serialisierung mit `System.Text.Json`
- Sichere Verzeichniserstellung und Fehlerbehandlung

## 🔔 Systemtray-Integration
Vollständige Integration in die Windows-Taskleiste:
- **NotifyIcon**: Zeigt aktuellen Status in der Taskleiste an
  - "Inaktiv" im Standard-Modus
  - "Aktiv" wenn AntiSleep läuft
- **Intelligentes Icon**: Verwendet das Anwendungs-Icon mit Fallback zu System-Icon
- **Kontextmenü** mit lokalisierten Einträgen:
  - Öffnen
  - Aktivierung umschalten
  - Beenden
- **Balloon-Benachrichtigungen** in der richtigen Sprache:
  - Programmstart
  - Modus aktiviert/deaktiviert
  - Hintergrund-Hinweis beim Schließen
- **Interaktive Benachrichtigungen**:
  - Klick auf Balloon-Tipp öffnet das Fenster
  - Doppelklick auf Tray-Icon öffnet das Fenster
- **Minimieren in Tray**: Beim Schließen wird die App in den Systemtray minimiert statt beendet

## 🖱️ Mausbewegung Features
- **Konfigurierbare Bewegung**:
  - Intervall einstellbar (Standard: 1000ms)
  - Distanz konfigurierbar (Standard: 1 Pixel)
  - Richtungswechsel für natürliche Bewegung
- **Sichtbare/Unsichtbare Mausbewegung**: 
  - Optional: Mausbewegung kann deaktiviert werden
  - System bleibt trotzdem wach ohne sichtbare Cursor-Bewegung
- **Windows API Integration**: 
  - Nutzt `SetThreadExecutionState` für zuverlässige Wach-Haltung
  - Verhindert Bildschirmschoner und Sleep-Modus

## 💻 Code-Verbesserungen
- **Saubere Architektur**:
  - Trennung von Logik und Lokalisierung
  - Separate Settings-Verwaltung
  - Fluent UI Styling in separater Methode
- **Bessere Organisation**:
  - `UpdateUITexts()` Methode für zentrale UI-Updates
  - `ApplyFluentUIStyle()` für konsistentes Design
  - Namespaces: `AntiSleep.Localization`, `AntiSleep.Settings`
- **Moderne C# Features**:
  - File-scoped namespaces
  - Null-coalescing Operator
  - Pattern Matching
  - Records für Settings (falls erweitert)
- **Fehlerbehandlung**:
  - Try-catch Blöcke bei I/O-Operationen
  - Debug-Ausgaben für Entwicklung
  - Graceful Fallbacks

## 🎯 Neue Features
- **Dynamische Button-Farben**: 
  - Blau (Aktivieren) → Rot (Deaktivieren) beim Umschalten
  - Visuelles Feedback für aktuellen Status
- **Status-Synchronisation**:
  - Button-Text, Tray-Icon-Tooltip und Farbe ändern sich synchron
  - Konsistente Darstellung des aktuellen Zustands
- **Professionelles Erscheinungsbild**:
  - Moderne Windows 11-ähnliche Oberfläche
  - Konsistente Verwendung von lokalisierten Strings
  - Benutzerfreundliche Bedienung

## 🛠️ Technische Details
- **.NET Version**: .NET 8.0
- **C# Version**: 12.0
- **UI Framework**: Windows Forms
- **Dependencies**:
  - `System.Text.Json` (Settings-Serialisierung)
  - Windows API (P/Invoke für SetThreadExecutionState)
- **Architektur**:
  - MVVM-ähnliches Pattern für Settings
  - Event-driven UI Updates
  - Singleton-ähnlicher LocalizationManager
