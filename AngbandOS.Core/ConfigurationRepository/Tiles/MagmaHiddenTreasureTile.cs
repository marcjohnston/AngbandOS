// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class MagmaHiddenTreasureTile : Tile
{
    private MagmaHiddenTreasureTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(PoundSignSymbol));
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "MagmaHidTreas";
    public override AlterAction? AlterAction => SaveGame.SingletonRepository.AlterActions.Get(nameof(TunnelAlterAction));
    public override string AppearAs => "Magma";
    public override bool BlocksLos => true;
    public override string? HiddenTreasureFor => "MagmaVisTreas";
    public override string Description => "magma vein";
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
