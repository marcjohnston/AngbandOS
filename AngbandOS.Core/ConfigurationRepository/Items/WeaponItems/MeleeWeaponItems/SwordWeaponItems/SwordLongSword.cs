// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class SwordLongSword : SwordItemClass
{
    private SwordLongSword(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(VerticalBarSymbol));
    public override ColourEnum Colour => ColourEnum.BrightWhite;
    public override string Name => "Long Sword";

    public override int[] Chance => new int[] { 1, 1, 0, 0 };
    public override int Cost => 300;
    public override int Dd => 2;
    public override int Ds => 5;
    public override string FriendlyName => "& Long Sword~";
    public override int Level => 10;
    public override int[] Locale => new int[] { 10, 20, 0, 0 };
    public override bool ShowMods => true;
    public override int Weight => 130;
    public override Item CreateItem() => new LongSwordWeaponItem(SaveGame);
}
