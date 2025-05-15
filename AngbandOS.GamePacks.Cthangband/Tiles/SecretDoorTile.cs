// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SecretDoorTile : TileGameConfiguration
{
    public override string SymbolName => nameof(PoundSignSymbol);
    public override string? AlterActionName => nameof(AlterActionsEnum.TunnelAlterAction);
    public override string? MimicTileName => nameof(WallBasicTile);
    public override bool BlocksLos => true;

    /// <summary>
    /// Returns false, because secret doors allow the scent trail to pass through.
    /// </summary>
    public override bool? BlocksScent => false;

    public override string Description => "granite wall";
    public override bool DimsOutsideLOS => true;
    public override bool IsWall => true;
    public override int MapPriority => 10;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;

    /// <summary>
    /// Returns true, because this is a secret door tile.
    /// </summary>
    public override bool IsSecretDoor => true;
}
