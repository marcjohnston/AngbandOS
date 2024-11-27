// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

/// <summary>
/// Processes the world turn by draining life from the player, when the player does not have anti-magic, 1 time in 1000.
/// </summary>
[Serializable]
internal class JewelJudgementDrainLifeScript : Script, IScriptItem
{
    private JewelJudgementDrainLifeScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScriptItem(Item item)
    {
        if (Game.DieRoll(999) == 1 && !Game.HasAntiMagic && Game.InvulnerabilityTimer.Value == 0)
        {
            Game.MsgPrint("The Jewel of Judgement drains life from you!");
            Game.TakeHit(Math.Min(Game.ExperienceLevel.IntValue, 50), "the Jewel of Judgement");
        }
    }
}
