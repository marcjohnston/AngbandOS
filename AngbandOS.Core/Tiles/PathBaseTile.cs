// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class PathBaseTile : Tile
{
    private PathBaseTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<PeriodSymbol>();
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "PathBase";
    public override string AppearAs => "PathBase";
    public override TileCategory Category => SaveGame.SingletonRepository.TileCategories.Get<OtherTileCategory>();
    public override string Description => "path base";
    public override bool DimsOutsideLOS => true;
    public override bool IsPassable => true;
    public override int MapPriority => 0;
    public override bool RunPast => true;
}