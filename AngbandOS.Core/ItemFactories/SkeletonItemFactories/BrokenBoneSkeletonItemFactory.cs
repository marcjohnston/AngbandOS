// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class BrokenBoneSkeletonItemFactory : ItemFactory
{
    private BrokenBoneSkeletonItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override bool IsBroken => true;
    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    protected override string SymbolBindingKey => nameof(TildeSymbol);
    public override ColorEnum Color => ColorEnum.Beige;
    public override string Name => "Broken Bone";

    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (0, 1)
    };
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    protected override string? DescriptionSyntax => "Broken Bone~";
    public override int Weight => 2;
    protected override string ItemClassBindingKey => nameof(SkeletonsItemClass);
    public override bool EasyKnow => true;
    public override int PackSort => 40;
    protected override string BreakageChanceProbabilityExpression => "50/100";
    public override bool HatesAcid => true;
}
