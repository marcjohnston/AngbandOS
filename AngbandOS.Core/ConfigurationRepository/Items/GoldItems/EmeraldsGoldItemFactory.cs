// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class EmeraldsGoldItemFactory : GoldItemFactory
{
    private EmeraldsGoldItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(DollarSignSymbol));
    public override ColorEnum Color => ColorEnum.Green;
    public override string Name => "emeralds";

    public override int Cost => 32;
    public override string FriendlyName => "emeralds";
    public override int Level => 1;
    public override Item CreateItem() => new EmeraldsGoldItem(SaveGame);
}
