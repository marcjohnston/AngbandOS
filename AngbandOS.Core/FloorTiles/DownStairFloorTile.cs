// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class DownStairFloorTile : FloorTile
{
    private DownStairFloorTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<GreaterThanSymbol>();
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "DownStair";
    public override string AppearAs => "DownStair";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.DownStair;
    public override string Description => "down staircase";
    public override bool DimsOutsideLOS => true;
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsPermanent => true;
    public override int MapPriority => 25;
}
