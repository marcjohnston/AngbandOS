// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class HardLeatherBootsArmorItemFactory : BootsArmorItemFactory
{
    private HardLeatherBootsArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(CloseBraceSymbol));
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override string Name => "Pair of Hard Leather Boots";

    public override int Ac => 3;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 12;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "& Pair~ of Hard Leather Boots";
    public override int Level => 5;
    public override int[] Locale => new int[] { 5, 0, 0, 0 };
    public override int Weight => 40;
    public override Item CreateItem() => new HardLeatherBootsArmorItem(SaveGame);
}
