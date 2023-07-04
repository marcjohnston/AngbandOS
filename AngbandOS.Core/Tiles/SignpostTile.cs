// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class SignpostTile : Tile
{
    private SignpostTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<ColonSymbol>();
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Signpost";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "Signpost";
    public override TileCategory Category => SaveGame.SingletonRepository.TileCategories.Get<TreeTileCategory>();
    public override string Description => "signpost";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 0;
}
