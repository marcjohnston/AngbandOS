// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class MetalLamellarHardArmorItemFactory : HardArmorItemFactory
{
    private MetalLamellarHardArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<OpenBraceSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightWhite;
    public override string Name => "Metal Lamellar Armour";

    public override int Ac => 23;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1250;
    public override int Dd => 1;
    public override int Ds => 6;
    public override string FriendlyName => "Metal Lamellar Armour~";
    public override int Level => 45;
    public override int[] Locale => new int[] { 45, 0, 0, 0 };
    public override int ToH => -3;
    public override int Weight => 340;
    public override Item CreateItem() => new MetalLamellarHardArmorItem(SaveGame);
}