// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class RustyChainMailHardArmorItemFactory : HardArmorItemFactory
{
    private RustyChainMailHardArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<OpenBraceSymbol>();
    public override ColourEnum Colour => ColourEnum.Red;
    public override string Name => "Rusty Chain Mail";

    public override int Ac => 14;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 550;
    public override int Dd => 1;
    public override int Ds => 4;
    public override string FriendlyName => "Rusty Chain Mail~";
    public override int Level => 25;
    public override int[] Locale => new int[] { 25, 0, 0, 0 };
    public override int ToA => -8;
    public override int ToH => -5;
    public override int Weight => 200;
    public override Item CreateItem() => new RustyChainMailHardArmorItem(SaveGame);
}