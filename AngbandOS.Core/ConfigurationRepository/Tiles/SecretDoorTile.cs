// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class SecretDoorTile : Tile
{
    private SecretDoorTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<PoundSignSymbol>();
    public override string Name => "SecretDoor";
    public override AlterAction? AlterAction => SaveGame.SingletonRepository.AlterActions.Get<TunnelAlterAction>();
    public override string AppearAs => "WallBasic";
    public override bool BlocksLos => true;

    /// <summary>
    /// Returns false, because secret doors allow the scent trail to pass through.
    /// </summary>
    public override bool BlocksScent => false;

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