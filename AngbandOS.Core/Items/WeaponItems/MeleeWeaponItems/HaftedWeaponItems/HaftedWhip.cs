// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class HaftedWhip : HaftedItemClass
{
    private HaftedWhip(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<BackSlashSymbol>();
    public override Colour Colour => Colour.Black;
    public override string Name => "Whip";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 30;
    public override int Dd => 1;
    public override int Ds => 6;
    public override string FriendlyName => "& Whip~";
    public override int Level => 3;
    public override int[] Locale => new int[] { 3, 0, 0, 0 };
    public override bool ShowMods => true;
    public override int Weight => 30;
    public override Item CreateItem() => new WhipHaftedWeaponItem(SaveGame);
}
