// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class PillarTile : Tile
{
    private PillarTile(Game game) : base(game) { } // This object is a singleton.
    protected override string SymbolName => nameof(PoundSignSymbol);
    protected override string? AlterActionName => nameof(TunnelAlterAction);
    public override bool BlocksLos => true;
    public override string Description => "pillar";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 12;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}