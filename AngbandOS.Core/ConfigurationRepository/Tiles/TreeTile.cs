// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class TreeTile : Tile
{
    private TreeTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<PoundSignSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightGreen;
    public override string Name => "Tree";
    public override AlterAction? AlterAction => SaveGame.SingletonRepository.AlterActions.Get<TunnelAlterAction>();
    public override string AppearAs => "Tree";
    public override bool BlocksLos => true;
    public override string Description => "tree";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 0;

    /// <summary>
    /// Returns true, because this tile is a tree.
    /// </summary>
    public override bool IsTree => true;
}