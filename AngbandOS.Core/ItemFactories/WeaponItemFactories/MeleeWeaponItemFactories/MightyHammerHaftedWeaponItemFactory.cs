// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class MightyHammerHaftedWeaponItemFactory : MeleeWeaponItemFactory
{
    private MightyHammerHaftedWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(BackSlashSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "Mighty Hammer";

    public override int Cost => 1000;
    public override int DamageDice => 3;
    public override int DamageSides => 9;
    public override string FriendlyName => "& Mighty Hammer~"; // TODO: This appears to cause a defect in identification
    public override bool InstaArt => true;
    public override int LevelNormallyFound => 15;
    public override bool ShowMods => true;
    public override int Weight => 200;
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
