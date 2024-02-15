// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class WaterBorderTile : Tile
{
    private WaterBorderTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(TildeSymbol));
    public override ColorEnum Color => ColorEnum.BrightBlue;
    public override string Name => "WaterBorder";
    protected override string? MimicTileName => "Water";
    public override bool BlocksLos => true;
    public override string Description => "sea";
    public override bool DimsOutsideLOS => true;
    public override bool IsPermanent => true;
    public override int MapPriority => 0;
    public override bool IsWater => true;
}
