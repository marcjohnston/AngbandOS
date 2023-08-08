// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json.Serialization;
using System.Text.Json;

namespace AngbandOS.Core.ConfigurationRepository.JsonConverters;

internal class TownJsonConverter : JsonConverter<Town>
{
    public override Town? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, Town town, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WritePropertyName(nameof(town.ExcludeFromRepository));
        writer.WriteBooleanValue(town.ExcludeFromRepository);

        writer.WritePropertyName(nameof(town.Name));
        writer.WriteStringValue(town.Name);

        writer.WritePropertyName(nameof(town.HousePrice));
        writer.WriteNumberValue(town.HousePrice);

        writer.WritePropertyName(nameof(town.Stores));
        writer.WriteStartArray();
        foreach (Store store in town.Stores)
        {
            writer.WriteStringValue(store.GetType().FullName);
        }
        writer.WriteEndArray();

        writer.WriteEndObject();
    }
}