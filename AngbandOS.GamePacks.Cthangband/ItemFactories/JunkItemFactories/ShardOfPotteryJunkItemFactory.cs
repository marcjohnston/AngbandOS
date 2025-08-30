// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShardOfPotteryJunkItemFactory : ItemFactoryGameConfiguration
{
    public override bool Valueless => true;
    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    public override string SymbolBindingKey => nameof(TildeSymbol);
    public override string Name => "Shard of Pottery";

    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (0, 1)
    };
    public override string? DescriptionSyntax => "Shard~ of Pottery";
    public override string ItemClassBindingKey => nameof(JunkItemClass);
    public override int PackSort => 38;
    public override string? ItemEnhancementBindingKey => nameof(ShardOfPotteryJunkItemFactoryItemEnhancement);
    public override string BreakageChanceProbabilityExpression => "100/100";
}
