// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class SignpostFloorTile : FloorTile
{
    private SignpostFloorTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ':';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Signpost";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "Signpost";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Tree;
    public override string Description => "signpost";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 0;
}