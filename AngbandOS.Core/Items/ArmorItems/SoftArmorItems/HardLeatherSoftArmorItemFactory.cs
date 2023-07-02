// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class HardLeatherSoftArmorItemFactory : SoftArmorItemClass
{
    private HardLeatherSoftArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<OpenParenthesisSymbol>();
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Hard Leather Armour";

    public override int Ac => 6;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 150;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Hard Leather Armour~";
    public override int Level => 5;
    public override int[] Locale => new int[] { 5, 0, 0, 0 };
    public override int ToH => -1;
    public override int Weight => 100;
    public override Item CreateItem() => new HardLeatherSoftArmorItem(SaveGame);
}
