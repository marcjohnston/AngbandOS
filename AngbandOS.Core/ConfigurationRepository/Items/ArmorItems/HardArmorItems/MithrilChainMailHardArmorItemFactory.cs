// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class MithrilChainMailHardArmorItemFactory : HardArmorItemFactory
{
    private MithrilChainMailHardArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(OpenBraceSymbol));
    public override ColourEnum Colour => ColourEnum.BrightBlue;
    public override string Name => "Mithril Chain Mail";

    public override int Ac => 28;
    public override int[] Chance => new int[] { 4, 0, 0, 0 };
    public override int Cost => 7000;
    public override int Dd => 1;
    public override int Ds => 4;
    public override string FriendlyName => "Mithril Chain Mail~";
    public override bool IgnoreAcid => true;
    public override int Level => 55;
    public override int[] Locale => new int[] { 55, 0, 0, 0 };
    public override int ToH => -1;
    public override int Weight => 150;
    public override Item CreateItem() => new MithrilChainMailHardArmorItem(SaveGame);
}
