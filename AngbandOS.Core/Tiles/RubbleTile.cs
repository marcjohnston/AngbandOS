// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class RubbleTile : Tile
{
    private RubbleTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<ColonSymbol>();
    public override string Name => "Rubble";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "Rubble";
    public override bool BlocksLos => true;
    public override string Description => "pile of rubble";
    public override bool DimsOutsideLOS => true;
    public override bool IsInteresting => true;
    public override int MapPriority => 12;
    public override bool YellowInTorchlight => true;

    /// <summary>
    /// Returns true, because this tile is rubble.
    /// </summary>
    public override bool IsRubble => true;
}