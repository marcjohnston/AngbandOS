// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ChainMailHardArmorItemFactory : HardArmorItemFactory
{
    private ChainMailHardArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '[';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Chain Mail";

    public override int Ac => 14;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 750;
    public override int Dd => 1;
    public override int Ds => 4;
    public override string FriendlyName => "Chain Mail~";
    public override int Level => 25;
    public override int[] Locale => new int[] { 25, 0, 0, 0 };
    public override int? SubCategory => 4;
    public override int ToH => -2;
    public override int Weight => 220;
    public override Item CreateItem() => new ChainMailHardArmorItem(SaveGame);
}