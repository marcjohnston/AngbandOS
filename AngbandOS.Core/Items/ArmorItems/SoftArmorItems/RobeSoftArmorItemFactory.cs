// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class RobeSoftArmorItemFactory : SoftArmorItemClass
{
    private RobeSoftArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '(';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Robe";

    public override int Ac => 2;
    public override int[] Chance => new int[] { 1, 1, 0, 0 };
    public override int Cost => 4;
    public override string FriendlyName => "& Robe~";
    public override int Level => 1;
    public override int[] Locale => new int[] { 1, 50, 0, 0 };
    public override int? SubCategory => 2;
    public override int Weight => 20;
    public override Item CreateItem() => new RobeSoftArmorItem(SaveGame);
}