// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class WallPermanentBuildingTile : Tile
{
    private WallPermanentBuildingTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<PoundSignSymbol>();
    public override string Name => "WallPermBuilding";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "WallPermBuilding";
    public override bool BlocksLos => true;
    public override TileCategory Category => SaveGame.SingletonRepository.TileCategories.Get<OtherTileCategory>();
    public override string Description => "building";
    public override bool DimsOutsideLOS => true;
    public override bool IsPermanent => true;
    public override bool IsWall => true;
    public override int MapPriority => 0;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}