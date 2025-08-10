// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CanineSkeletonSkeletonItemFactory : ItemFactoryGameConfiguration
{
    public override bool IsBroken => true;
    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    public override string SymbolBindingKey => nameof(TildeSymbol);
    public override ColorEnum Color => ColorEnum.Beige;
    public override string Name => "Canine Skeleton";

    public override string? DescriptionSyntax => "Canine Skeleton~";
    public override int LevelNormallyFound => 1;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (1, 1)
    };
    public override string ItemClassBindingKey => nameof(SkeletonsItemClass);
    public override string? ItemEnhancementBindingKey => nameof(CanineSkeletonSkeletonItemFactoryItemEnhancement);
    public override int PackSort => 40;
    public override string BreakageChanceProbabilityExpression => "50/100";
    public override bool HatesAcid => true;
}
