// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SummonGreaterUndeadScript : Script, IScript, ICastSpellScript
{
    private SummonGreaterUndeadScript(Game game) : base(game) { }

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
        Game.MsgPrint("You concentrate on the image of a greater undead being...");
        if (Game.DieRoll(10) > 3)
        {
            if (!Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.ExperienceLevel.IntValue, Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(HiUndeadNoUniquesMonsterRaceFilter)), true, true))
            {
                Game.MsgPrint("No-one ever turns up.");
            }
        }
        else if (Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.ExperienceLevel.IntValue, Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(HiUndeadNoUniquesMonsterRaceFilter)), true, false))
        {
            Game.MsgPrint("The summoned undead creature gets angry!");
        }
        else
        {
            Game.MsgPrint("No-one ever turns up.");
        }
    }
    public string LearnedDetails => "control 70%";
}
