// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class YellowSignSigilTile : Tile
{
    private YellowSignSigilTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(SemiColonSymbol));
    public override ColourEnum Colour => ColourEnum.BrightYellow;
    public override string Name => "YellowSign";
    public override string AppearAs => "YellowSign";
    public override string Description => "Yellow Sign";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override int MapPriority => 20;

    /// <summary>
    /// Returns false, because monsters cannot occupy Sigil tiles.
    /// </summary>
    public override bool AllowMonsterToOccupy => false;

}
