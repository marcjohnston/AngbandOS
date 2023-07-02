// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class SoftStuddedLeatherSoftArmorItemFactory : SoftArmorItemClass
{
    private SoftStuddedLeatherSoftArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<OpenParenthesisSymbol>();
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Soft Studded Leather";

    public override int Ac => 5;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 35;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Soft Studded Leather~";
    public override int Level => 3;
    public override int[] Locale => new int[] { 3, 0, 0, 0 };
    public override int Weight => 90;
    public override Item CreateItem() => new SoftStuddedLeatherSoftArmorItem(SaveGame);
}
