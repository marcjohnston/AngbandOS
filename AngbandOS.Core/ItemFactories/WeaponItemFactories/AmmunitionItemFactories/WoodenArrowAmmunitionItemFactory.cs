// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class WoodenArrowAmmunitionItemFactory : AmmunitionItemFactory
{
    private WoodenArrowAmmunitionItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(OpenBracketSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Arrow";

    public override int Cost => 1;
    public override int DamageDice => 1;
    public override int DamageSides => 4;
    protected override string? DescriptionSyntax => "Arrow~";
    public override int LevelNormallyFound => 3;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (3, 1),
        (15, 1)
    };
    public override bool ShowMods => true;
    public override int Weight => 2;
    protected override string ItemClassName => nameof(ArrowsItemClass);
    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (500, "5d5-5")
    };

    public override int PackSort => 34;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    /// <summary>
    /// Returns true, for all arrows.
    /// </summary>
    public override bool KindIsGood => true;

    public override int MakeObjectCount => Game.DiceRoll(6, 7);
    public override int PercentageBreakageChance => 25;

    public override bool IsWeapon => true;
    public override bool IdentityCanBeSensed => true;
    public override bool GetsDamageMultiplier => true;
}
