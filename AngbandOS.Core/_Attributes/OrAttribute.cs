// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class OrAttribute : Attribute, IToJson
{
    public OrAttribute(Game game, OrAttributeGameConfiguration gameConfiguration) : base(game) // This object is a singleton
    {
        Key = gameConfiguration.GetKey;
    }
    public OrAttribute(Game game, OrAttributeGameConfiguration gameConfiguration, ObjectGameStateBag gameStateBag) : base(game, gameStateBag) // This object is a singleton
    {
        Key = gameConfiguration.GetKey;
    }
    public override EffectiveAttributeValue CreateEffectiveAttributeValue() => new OrEffectiveAttributeValue(Game, this);
    public override string Key { get; }

    public string ToJson()
    {
        OrAttributeGameConfiguration gameConfiguration = new()
        {
            Key = Key,
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }
}
