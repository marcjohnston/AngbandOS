// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class SwordShortSword : SwordItemClass
{
    private SwordShortSword(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(VerticalBarSymbol));
    public override ColourEnum Colour => ColourEnum.BrightWhite;
    public override string Name => "Short Sword";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 90;
    public override int Dd => 1;
    public override int Ds => 7;
    public override string FriendlyName => "& Short Sword~";
    public override int Level => 5;
    public override int[] Locale => new int[] { 5, 0, 0, 0 };
    public override bool ShowMods => true;
    public override int Weight => 80;
    public override Item CreateItem() => new ShortSwordWeaponItem(SaveGame);
}
