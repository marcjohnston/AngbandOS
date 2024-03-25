// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CreateDimensionDoorScript : Script, IScript
{
    private CreateDimensionDoorScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.MsgPrint("You open a dimensional gate. Choose a destination.");
        if (!Game.TgtPt(out int ii, out int ij))
        {
            return;
        }
        Game.Energy -= 60 - Game.ExperienceLevel.Value;
        if (!Game.GridPassableNoCreature(ij, ii) || Game.Grid[ij][ii].InVault || Game.Distance(ij, ii, Game.MapY, Game.MapX) > Game.ExperienceLevel.Value + 2 || Game.RandomLessThan(Game.ExperienceLevel.Value * Game.ExperienceLevel.Value / 2) == 0)
        {
            Game.MsgPrint("You fail to exit the astral plane correctly!");
            Game.Energy -= 100;
            Game.RunScriptInt(nameof(TeleportSelfScript), 10);
        }
        else
        {
            Game.TeleportPlayerTo(ij, ii);
        }
    }
}
