// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class BrokenDaggerWeaponItemFactory : MeleeWeaponItemFactory
{
    private BrokenDaggerWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(VerticalBarSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "Broken Dagger";

    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (0, 1)
    };
    public override int Cost => 1;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    protected override string? DescriptionSyntax => "Broken Dagger~";
    public override bool ShowMods => true;
    public override int BonusDamage => -4;
    public override int BonusHit => -2;
    public override int Weight => 5;
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