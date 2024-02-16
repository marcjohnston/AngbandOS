// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class BlackMarketStoreTile : Tile
{
    private BlackMarketStoreTile(SaveGame saveGame) : base(saveGame) { }
    public override bool BlocksLos => true;
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsPermanent => true;
    public override bool IsShop => true;
    public override int MapPriority => 0;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(NumberSevenSymbol));
    public override ColorEnum Color => ColorEnum.Black;
    public override string Description => "Black Market";
}

