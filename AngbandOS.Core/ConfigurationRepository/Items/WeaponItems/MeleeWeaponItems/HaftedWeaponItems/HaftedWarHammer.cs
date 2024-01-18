// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class HaftedWarHammer : HaftedItemClass
{
    private HaftedWarHammer(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(BackSlashSymbol));
    public override ColourEnum Colour => ColourEnum.Black;
    public override string Name => "War Hammer";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 225;
    public override int Dd => 3;
    public override int Ds => 3;
    public override string FriendlyName => "& War Hammer~";
    public override int Level => 5;
    public override int[] Locale => new int[] { 5, 0, 0, 0 };
    public override bool ShowMods => true;
    public override int Weight => 120;
    public override Item CreateItem() => new WarHammerHaftedWeaponItem(SaveGame);
}
