// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class MoveBodyScript : Script, IScript, ICastSpellScript
{
    private MoveBodyScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Teleports the player to a chosen destination.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.MsgPrint("You focus your Chi. Choose a destination.");
        if (!Game.TgtPt(out int ii, out int ij))
        {
            return;
        }
        Game.Energy -= 60 - Game.ExperienceLevel.IntValue;
        if (!Game.GridPassableNoCreature(ij, ii) || Game.Map.Grid[ij][ii].InVault || Game.Distance(ij, ii, Game.MapY.IntValue, Game.MapX.IntValue) > Game.ExperienceLevel.IntValue + 2 || Game.RandomLessThan(Game.ExperienceLevel.IntValue * Game.ExperienceLevel.IntValue / 2) == 0)
        {
            Game.MsgPrint("You fail to concentrate correctly!");
            Game.Energy -= 100;
            Game.RunScript(nameof(TeleportSelf10TeleportSelfScript));
        }
        else
        {
            Game.TeleportPlayerTo(ij, ii);
        }
    }
    public string LearnedDetails => $"range {Game.ExperienceLevel.IntValue + 2}";
}
