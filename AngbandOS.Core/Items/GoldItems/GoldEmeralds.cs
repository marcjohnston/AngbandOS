// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class GoldEmeralds : GoldItemClass
{
    private GoldEmeralds(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<DollarSignSymbol>();
    public override Colour Colour => Colour.Green;
    public override string Name => "emeralds";

    public override int Cost => 32;
    public override string FriendlyName => "emeralds";
    public override int Level => 1;
    public override Item CreateItem() => new EmeraldsGoldItem(SaveGame);
}
