// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IronSpikeItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(TildeSymbol);
    public override string Name => "Iron Spike";

    public override string? DescriptionSyntax => "Iron Spike~";
    public override int LevelNormallyFound => 1;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (1, 1)
    };
    public override string ItemClassBindingKey => nameof(SpikesItemClass);

    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (500, "5d5-5")
    };

    public override string MakeObjectCountExpression => "6d7";
    public override string? ItemEnhancementBindingKey => nameof(IronSpikeItemFactoryItemEnhancement);
    public override bool CanSpikeDoorClosed => true;
    public override int PackSort => 37;
}
