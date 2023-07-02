// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class ScarecrowFloorTile : FloorTile
{
    private ScarecrowFloorTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerTSymbol>();
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Scarecrow";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "Scarecrow";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Tree;
    public override string Description => "scarecrow";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 0;
}
