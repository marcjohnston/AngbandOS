// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.PhysicalAttributeSets;

[Serializable]
internal sealed class PhysicalAttributeSet : IGetKey, IToJson
{
    private readonly Game Game;
    public PhysicalAttributeSet(Game game, PhysicalAttributeSetGameConfiguration physicalAttributeSetGameConfiguration)
    {
        Game = game;
        Key = Key = physicalAttributeSetGameConfiguration.Key ?? physicalAttributeSetGameConfiguration.GetType().Name;
        BaseHeight = physicalAttributeSetGameConfiguration.BaseHeight;
        HeightRange = physicalAttributeSetGameConfiguration.HeightRange;
        BaseWeight = physicalAttributeSetGameConfiguration.BaseWeight;
        WeightRange = physicalAttributeSetGameConfiguration.WeightRange;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        PhysicalAttributeSetGameConfiguration definition = new PhysicalAttributeSetGameConfiguration()
        {
            Key = Key,
            BaseHeight = BaseHeight,
            HeightRange = HeightRange,
            BaseWeight = BaseWeight,
            WeightRange = WeightRange
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }

    public string Key { get; }

    public string GetKey => Key;

    public void Bind() { }

    public int BaseHeight { get; }
    public int HeightRange { get; }
    public int BaseWeight { get; }
    public int WeightRange { get; }
}
