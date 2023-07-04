// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class FireTrapTile : Tile
{
    private FireTrapTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<CaretSymbol>();
    public override Colour Colour => Colour.Brown;
    public override string Name => "FireTrap";
    public override AlterAction? AlterAction => new DisarmAlterAction();
    public override string AppearAs => "FireTrap";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Other;
    public override string Description => "discolored spot";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsTrap => true;
    public override int MapPriority => 20;
}
