// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class OpenDoorTile : Tile
{
    private OpenDoorTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<SingleQuoteSymbol>();
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "OpenDoor";
    public override AlterAction? AlterAction => new CloseAlterAction();
    public override string AppearAs => "OpenDoor";
    public override TileCategory Category => SaveGame.SingletonRepository.TileCategories.Get<OpenDoorwayTileCategory>();
    public override string Description => "open door";
    public override bool DimsOutsideLOS => true;
    public override bool IsPassable => true;
    public override int MapPriority => 17;
}