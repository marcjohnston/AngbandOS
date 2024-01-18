// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ShieldLargeLeatherShield : ShieldItemClass
{
    private ShieldLargeLeatherShield(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(CloseParenthesisSymbol));
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override string Name => "Large Leather Shield";

    public override int Ac => 4;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 120;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "& Large Leather Shield~";
    public override int Level => 15;
    public override int[] Locale => new int[] { 15, 0, 0, 0 };
    public override int Weight => 100;
    public override Item CreateItem() => new LargeLeatherShieldArmorItem(SaveGame);
}
