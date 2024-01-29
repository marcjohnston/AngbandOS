// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SoftLeatherSoftArmorItemFactory : SoftArmorItemFactory
{
    private SoftLeatherSoftArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(OpenParenthesisSymbol));
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Soft Leather Armor";

    public override int Ac => 4;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 18;
    public override string FriendlyName => "Soft Leather Armor~";
    public override int Level => 3;
    public override int[] Locale => new int[] { 3, 0, 0, 0 };
    public override int Weight => 80;
    public override Item CreateItem() => new Item(SaveGame, this);
}
