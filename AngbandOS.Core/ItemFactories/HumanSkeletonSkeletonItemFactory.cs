// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class HumanSkeletonSkeletonItemFactory : ItemFactory
{
    private HumanSkeletonSkeletonItemFactory(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    protected override string SymbolName => nameof(TildeSymbol);
    public override ColorEnum Color => ColorEnum.Beige;
    public override string Name => "Human Skeleton";

    public override int DamageDice => 1;
    public override int DamageSides => 2;
    protected override string? DescriptionSyntax => "Human Skeleton~";
    public override int LevelNormallyFound => 5;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (5, 1)
    };
    public override int Weight => 60;
    protected override string ItemClassName => nameof(SkeletonsItemClass);
    public override bool EasyKnow => true;
    public override int PackSort => 40;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Skeleton;
    public override int PercentageBreakageChance => 50;
    public override bool HatesAcid => true;
}