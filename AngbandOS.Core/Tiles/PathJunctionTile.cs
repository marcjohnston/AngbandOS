// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class PathJunctionTile : Tile
{
    private PathJunctionTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<PlusSignSymbol>();
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "PathJunction";
    public override string AppearAs => "PathJunction";
    public override TileCategory Category => SaveGame.SingletonRepository.TileCategories.Get<OtherTileCategory>();
    public override string Description => "path";
    public override bool DimsOutsideLOS => true;
    public override bool IsPassable => true;
    public override int MapPriority => 0;
}
