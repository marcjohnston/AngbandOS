// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class InvisFloorTile : FloorTile
{
    private InvisFloorTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override string Name => "Invis";
    public override string AppearAs => "Invis";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.UnidentifiedTrap;
    public override string Description => "invisible trap";
    public override bool DimsOutsideLOS => true;
    public override bool IsPassable => true;
    public override int MapPriority => 5;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}