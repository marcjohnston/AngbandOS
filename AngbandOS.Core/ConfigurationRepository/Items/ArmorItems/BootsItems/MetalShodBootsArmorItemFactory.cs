// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class MetalShodBootsArmorItemFactory : BootsArmorItemFactory
{
    private MetalShodBootsArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(CloseBraceSymbol));
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Pair of Metal Shod Boots";

    public override int Ac => 6;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 50;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "& Pair~ of Metal Shod Boots";
    public override int Level => 20;
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override int Weight => 80;
    public override Item CreateItem() => new MetalShodBootsArmorItem(SaveGame);
}
