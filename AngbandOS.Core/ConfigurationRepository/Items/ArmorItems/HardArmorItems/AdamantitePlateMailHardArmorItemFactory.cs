// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class AdamantitePlateMailHardArmorItemFactory : HardArmorItemFactory
{
    private AdamantitePlateMailHardArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<OpenBraceSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightGreen;
    public override string Name => "Adamantite Plate Mail";

    public override int Ac => 40;
    public override int[] Chance => new int[] { 8, 0, 0, 0 };
    public override int Cost => 20000;
    public override int Dd => 2;
    public override int Ds => 4;
    public override string FriendlyName => "Adamantite Plate Mail~";
    public override bool IgnoreAcid => true;
    public override int Level => 75;
    public override int[] Locale => new int[] { 75, 0, 0, 0 };
    public override int ToH => -4;
    public override int Weight => 420;
    public override Item CreateItem() => new AdamantitePlateMailHardArmorItem(SaveGame);
}