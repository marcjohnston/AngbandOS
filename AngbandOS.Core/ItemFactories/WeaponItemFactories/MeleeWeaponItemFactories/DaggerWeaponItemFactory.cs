// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DaggerWeaponItemFactory : MeleeWeaponItemFactory
{
    private DaggerWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(VerticalBarSymbol);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "Dagger";

    public override int Cost => 10;
    public override int DamageDice => 1;
    public override int DamageSides => 4;
    protected override string? DescriptionSyntax  => "& Dagger~";
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (0, 1),
        (5, 1),
        (10, 1),
        (20, 1)
    };
    public override bool ShowMods => true;
    public override int Weight => 12;
    protected override bool CanBeWeaponOfLaw => true;
    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (100, "3d5-3")
    };

    protected override bool CanBeWeaponOfSharpness => true;
    protected override bool CapableOfVorpalSlaying => true;
    protected override string ItemClassName => nameof(SwordsItemClass);
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Sword;
    public override bool HatesAcid => true;
    public override int PackSort => 28;

    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanVorpalSlay => true;
}
