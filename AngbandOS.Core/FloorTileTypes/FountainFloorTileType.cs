// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class FountainFloorTileType : FloorTileType
{
    private FountainFloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '~';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Fountain";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "Fountain";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "fountain";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 0;
}
