// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json.Serialization;
using System.Text.Json;

namespace AngbandOS.Core.ConfigurationRepository.JsonConverters;

internal class ArrayOfStoreJsonConverter : JsonConverter<Store[]>
{
    private readonly SaveGame SaveGame;
    public ArrayOfStoreJsonConverter(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public override Store[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, Store[] stores, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (Store store in stores)
        {
            writer.WriteStringValue(store.GetType().Name);
        }
        writer.WriteEndArray();
    }
}