// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class PathBorderNSTile : Tile
{
    private PathBorderNSTile(Game game) : base(game) { } // This object is a singleton.
    protected override string SymbolName => nameof(VerticalBarSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override bool IsPath => true;
    public override bool BlocksLos => true;
    public override string Description => "path";
    public override bool DimsOutsideLOS => true;
    public override bool IsPermanent => true;
    public override int MapPriority => 0;
    public override bool IsBorder => true;

}