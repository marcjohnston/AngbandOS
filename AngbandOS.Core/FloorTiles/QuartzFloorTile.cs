// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class QuartzFloorTile : FloorTile
{
    private QuartzFloorTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Quartz";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "Quartz";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Vein;
    public override string Description => "quartz vein";
    public override bool DimsOutsideLOS => true;
    public override bool IsWall => true;
    public override int MapPriority => 11;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}