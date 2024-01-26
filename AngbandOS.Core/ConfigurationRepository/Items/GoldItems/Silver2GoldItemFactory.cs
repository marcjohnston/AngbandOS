// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class Silver2GoldItemFactory : GoldItemFactory
{
    private Silver2GoldItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(DollarSignSymbol));
    public override ColorEnum Color => ColorEnum.Silver;
    public override string Name => "silver**";

    public override int Cost => 8;
    public override string FriendlyName => "silver";
    public override int Level => 1;
    public override Item CreateItem() => new Silver2GoldItem(SaveGame);
}
