// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class GoldGold2 : GoldItemFactory
{
    private GoldGold2(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<DollarSignSymbol>();
    public override ColourEnum Colour => ColourEnum.Gold;
    public override string Name => "gold**";

    public override int Cost => 16;
    public override string FriendlyName => "gold";
    public override int Level => 1;
    public override Item CreateItem() => new Gold2GoldItem(SaveGame);
}