// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class HardArmorMetalBrigandineArmour : HardArmorItemClass
{
    private HardArmorMetalBrigandineArmour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '[';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Metal Brigandine Armour";

    public override int Ac => 19;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1100;
    public override int Dd => 1;
    public override int Ds => 4;
    public override string FriendlyName => "Metal Brigandine Armour~";
    public override int Level => 35;
    public override int[] Locale => new int[] { 35, 0, 0, 0 };
    public override int? SubCategory => 9;
    public override int ToH => -3;
    public override int Weight => 290;
    public override Item CreateItem() => new MetalBrigandineArmourHardArmorItem(SaveGame);
}
