// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class SummonRuneFloorTile : FloorTile
{
    private SummonRuneFloorTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '^';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "SummonRune";
    public override AlterAction? AlterAction => new DisarmAlterAction();
    public override string AppearAs => "SummonRune";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "strange rune";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsTrap => true;
    public override int MapPriority => 20;
}