// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SummonElementalScript : Script, IScript, ICastSpellScript
{
    private SummonElementalScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (Game.DieRoll(6) > 3)
        {
            if (!Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.ExperienceLevel.IntValue, Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(ElementalMonsterRaceFilter)), false, true))
            {
                Game.MsgPrint("No-one ever turns up.");
            }
        }
        else if (Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.ExperienceLevel.IntValue, Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(ElementalMonsterRaceFilter)), true, false))
        {
            Game.MsgPrint("You fail to control the elemental creature!");
        }
        else
        {
            Game.MsgPrint("No-one ever turns up.");
        }
    }
    public string LearnedDetails => "control 50%";
}
