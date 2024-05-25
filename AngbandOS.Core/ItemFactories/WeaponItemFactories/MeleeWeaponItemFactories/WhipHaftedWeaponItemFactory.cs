// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class WhipHaftedWeaponItemFactory : MeleeWeaponItemFactory
{
    private WhipHaftedWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(BackSlashSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "Whip";

    public override int Cost => 30;
    public override int DamageDice => 1;
    public override int DamageSides => 6;
    protected override string? DescriptionSyntax  => "& Whip~";
    public override int LevelNormallyFound => 3;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (3, 1)
    };
    public override bool ShowMods => true;
    public override int Weight => 30;
    protected override bool CanBeWeaponOfLaw => true;
    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (100, "3d5-3")
    };

    protected override string ItemClassName => nameof(HaftedWeaponsItemClass);
    public override int PackSort => 30;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Hafted;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;
}
