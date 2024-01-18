// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class MagmaVisibleTreasureTile : Tile
{
    private MagmaVisibleTreasureTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(AsteriskSymbol));
    public override ColourEnum Colour => ColourEnum.BrightOrange;
    public override string Name => "MagmaVisTreas";
    public override AlterAction? AlterAction => SaveGame.SingletonRepository.AlterActions.Get(nameof(TunnelAlterAction));
    public override string AppearAs => "MagmaVisTreas";
    public override bool BlocksLos => true;
    public override bool IsVisibleTreasure => true;
    public override string Description => "magma vein with treasure";
    public override bool DimsOutsideLOS => true;
    public override bool IsWall => true;
    public override int MapPriority => 19;
    public override bool RunPast => true;

    /// <summary>
    /// Returns true because this tile is a vein.
    /// </summary>
    public override bool IsVein => true;
}
