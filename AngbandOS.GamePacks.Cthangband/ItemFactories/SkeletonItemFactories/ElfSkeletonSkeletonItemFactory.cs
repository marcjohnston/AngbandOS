// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ElfSkeletonSkeletonItemFactory : ItemFactoryGameConfiguration
{
    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    public override string SymbolBindingKey => nameof(TildeSymbol);
    public override string Name => "Elf Skeleton";

    public override string? DescriptionSyntax => "Elf Skeleton~";
    public override int LevelNormallyFound => 5;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (5, 1)
    };
    public override string ItemClassBindingKey => nameof(SkeletonsItemClass);
    public override string? ItemEnhancementBindingKey => nameof(ElfSkeletonSkeletonItemFactoryItemEnhancement);
    public override int PackSort => 40;
    public override string BreakageChanceProbabilityExpression => "50/100";
    public override bool IsGood => true;
}
