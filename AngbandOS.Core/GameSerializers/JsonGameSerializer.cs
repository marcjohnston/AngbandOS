// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal class JsonGameSerializer : IGameSerializer
{
    public byte[] Serialize(SaveGameData saveGameData)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = false
        };

        options.Converters.Add(new GameStateBagConverter());
        return JsonSerializer.SerializeToUtf8Bytes(saveGameData, options);
    }
    public SaveGameData Deserialize(byte[] serializedSaveGameData)
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new GameStateBagConverter());
        SaveGameData? saveGameData = JsonSerializer.Deserialize<SaveGameData>(serializedSaveGameData, options);
        if (saveGameData is null)
        {
            throw new Exception("Failed to deserialize game data.");
        }
        return saveGameData;
    }
}
