// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class QuartzHiddenTreasureTile : Tile
{
    private QuartzHiddenTreasureTile(Game game) : base(game) { } // This object is a singleton.
    protected override string SymbolName => nameof(PoundSignSymbol);
    protected override string? AlterActionName => nameof(TunnelAlterAction);
    protected override string? MimicTileName => nameof(QuartzTile);
    public override bool BlocksLos => true;
    public override bool IsTreasure => true;

    protected override string? HiddenTreasureForTileName => nameof(QuartzVisibleTreasureTile);
    public override string Description => "quartz vein";
    public override bool DimsOutsideLOS => true;
    public override bool IsWall => true;
    public override int MapPriority => 11;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;

    /// <summary>
    /// Returns true because this tile is a vein.
    /// </summary>
    public override bool IsVein => true;
}
