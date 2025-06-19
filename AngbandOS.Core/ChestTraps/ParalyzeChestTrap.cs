// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.ChestTraps;

[Serializable]
internal class ParalyzeChestTrap : ChestTrap
{
    private ParalyzeChestTrap(Game game) : base(game) { }
    public override bool Activate(int x, int y)
    {
        Game.RunScript(nameof(APuffOfYellowGasSurroundsYouRenderMessageScript));
        if (!Game.HasFreeAction)
        {
            Game.ParalysisTimer.AddTimer(10 + Game.DieRoll(20));
        }
        return false;
    }

    public override string Description => "(Gas Trap)";
}
