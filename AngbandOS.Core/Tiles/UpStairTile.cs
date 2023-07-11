// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class UpStairTile : Tile
{
    private UpStairTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LessThanSymbol>();
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "UpStair";
    public override string AppearAs => "UpStair";
    public override TileCategory Category => SaveGame.SingletonRepository.TileCategories.Get<UpStairTileCategory>();
    public override string Description => "up staircase";
    public override bool DimsOutsideLOS => true;
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsPermanent => true;
    public override int MapPriority => 25;

    /// <summary>
    /// Returns true, because up stairs should be reveals with the DetectStairsScript.
    /// </summary>
    public override bool IsRevealedWithDetectStairsScript => true;
}
