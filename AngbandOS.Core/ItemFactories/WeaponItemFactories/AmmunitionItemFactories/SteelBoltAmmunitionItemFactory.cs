// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SteelBoltAmmunitionItemFactory : AmmunitionItemFactory
{
    private SteelBoltAmmunitionItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(OpenBracketSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Bolt";

    public override int Cost => 2;
    public override int DamageDice => 1;
    public override int DamageSides => 5;
    protected override string? DescriptionSyntax => "Bolt~";
    public override int LevelNormallyFound => 3;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (3, 1),
        (25, 1)
    };
    public override bool ShowMods => true;
    public override int Weight => 3;
    protected override string ItemClassName => nameof(BoltsItemClass);
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Bolt;
    public override int PackSort => 33;

    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (500, "5d5-5")
    };

    /// <summary>
    /// Returns true for all bolts.
    /// </summary>
    public override bool KindIsGood => true;


    public override bool HatesAcid => true;
    public override int MakeObjectCount => Game.DiceRoll(6, 7);
    public override int PercentageBreakageChance => 25;

    public override bool IsWeapon => true;
    public override bool CanBeFired => true;
    public override bool IdentityCanBeSensed => true;
    public override bool GetsDamageMultiplier => true;
}
