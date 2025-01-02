// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BoozeScript : Script, IIdentifiedScript
{
    private BoozeScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteIdentifiedScript()
    {
        bool isIdentified = false;

        // Confusion makes you confused and possibly other effects
        if (!(Game.HasConfusionResistance || Game.HasChaosResistance))
        {
            if (Game.ConfusedTimer.AddTimer(Game.RandomLessThan(20) + 15))
            {
                isIdentified = true;
            }
            // 50% chance of having hallucinations
            if (Game.DieRoll(2) == 1)
            {
                if (Game.HallucinationsTimer.AddTimer(Game.RandomLessThan(150) + 150))
                {
                    isIdentified = true;
                }
            }
            // 1 in 13 chance of blacking out and waking up somewhere else
            if (Game.DieRoll(13) == 1)
            {
                isIdentified = true;
                // 1 in 3 chance of losing your memories after blacking out
                if (Game.DieRoll(3) == 1)
                {
                    Game.LoseAllInfo();
                }
                else
                {
                    Game.RunScript(nameof(DarkScript));
                }
                Game.RunScriptInt(nameof(TeleportSelfScript), 100);
                Game.RunScript(nameof(DarkScript));
                Game.MsgPrint("You wake up somewhere with a sore head...");
                Game.MsgPrint("You can't remember a thing, or how you got here!");
            }
        }
        return new IdentifiedResult(isIdentified);
    }
}