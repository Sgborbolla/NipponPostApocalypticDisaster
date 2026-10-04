// ============================================================================
//  SaveManager.cs - Persistencia minima del hito 0 (§18.1, punto 1).
//
//  §18.1: "SaveManager (C#) - res://game/Core/SaveManager.cs con
//  SaveData { bool tutorial_completed, string text_lang, bool first_run }
//  guardado en user://npad.save (JSON)".
//
//  Solo se guarda lo que el hito 0 necesita. El save de una run entera ( relics,
//  progreso por piso, deaths) no se disena todavia: §18.1 es un veredicto
//  PRE-PROGRAMACION, y meter campos que luego hay que migrar sale mas caro que
//  volver a escribirlos.
//
//  §4.7 y §18.0: tutorial_completed solo se marca true al TERMINAR el tutorial
//  interactivo, nunca al saltarselo. first_run distingue la primera ejecucion
//  (que muestra el tutorial) de las siguientes.
//
//  NOTA DE RUTA: este archivo vive en res://game/Core/ porque todavia no hay
//  project.godot. Cuando se cree, la ruta es res://game/Core/SaveManager.cs.
// ============================================================================

using Godot;
using System.Text.Json;

namespace NPAD.Game.Core;

public partial class SaveManager : Node
{
    [Signal]
    public delegate void DataLoadedEventHandler();

    private string SavePath = "user://npad.save";
    public SaveData CurrentData { get; private set; } = null!;

    public override void _Ready()
    {
        LoadData();
    }

    public void LoadData()
    {
        if (FileAccess.FileExists(SavePath))
        {
            using var file = FileAccess.Open(SavePath, FileAccess.ModeFlags.Read);
            string jsonStr = file.GetAsText();
            CurrentData = JsonSerializer.Deserialize<SaveData>(jsonStr) ?? new SaveData();
        }
        else
        {
            CurrentData = new SaveData();
            SaveDataToDisk();
        }
        EmitSignal(SignalName.DataLoaded);
    }

    public void SaveDataToDisk()
    {
        using var file = FileAccess.Open(SavePath, FileAccess.ModeFlags.Write);
        string jsonStr = JsonSerializer.Serialize(CurrentData, new JsonSerializerOptions { WriteIndented = true });
        file.StoreString(jsonStr);
    }
}

/// <summary>
/// §18.1. Campos minimos del hito 0. Sin el save de run: §18.1 es un veredicto
/// pre-programacion y anadir campos aqui obliga a migrarlos despues.
/// </summary>
[System.Serializable]
public class SaveData
{
    /// <summary>§4.7. Solo true al COMPLETAR el tutorial, nunca al saltarlo.</summary>
    public bool tutorial_completed { get; set; } = false;

    /// <summary>§7.4. Idioma de texto: "es" o "en". El VO va siempre en JA aparte.</summary>
    public string text_lang { get; set; } = "es";

    /// <summary>Primera ejecucion. El tutorial interactivo se muestra aqui (§4.7).</summary>
    public bool first_run { get; set; } = true;
}
