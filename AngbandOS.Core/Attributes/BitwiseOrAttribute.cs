// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal class BitwiseOrAttribute : Attribute, IToJson
{
    public BitwiseOrAttribute(Game game, BitwiseOrAttributeGameConfiguration gameConfiguration) : base(game) // This object is a singleton
    {
        Key = gameConfiguration.GetKey;
    }
    public override EffectiveAttributeValue CreateEffectiveAttributeValue() => new BitwiseOrEffectiveAttributeValue(Game, this);
    public override string Key { get; }

    public string ToJson()
    {
        BitwiseOrAttributeGameConfiguration gameConfiguration = new()
        {
            Key = Key,
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }

    public override string ToString()
    {
        return $"Or: {base.ToString()}";
    }
}
