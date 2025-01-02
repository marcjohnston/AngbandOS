// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SummonDemonServantScript : Script, IScript, ICastSpellScript
{
    private SummonDemonServantScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Summons a demon monster.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (Game.DieRoll(3) == 1)
        {
            if (Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.ExperienceLevel.IntValue * 3 / 2, Game.SingletonRepository.Get<MonsterFilter>(nameof(DemonMonsterFilter)), true, false))
            {
                Game.MsgPrint("The area fills with a stench of sulphur and brimstone.");
                Game.MsgPrint("'NON SERVIAM! Wretch! I shall feast on thy mortal soul!'");
            }
            else
            {
                Game.MsgPrint("No-one ever turns up.");
            }
        }
        else
        {
            if (Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.ExperienceLevel.IntValue * 3 / 2, Game.SingletonRepository.Get<MonsterFilter>(nameof(DemonMonsterFilter)), Game.ExperienceLevel.IntValue == 50, true))
            {
                Game.MsgPrint("The area fills with a stench of sulphur and brimstone.");
                Game.MsgPrint("'What is thy bidding... Master?'");
            }
            else
            {
                Game.MsgPrint("No-one ever turns up.");
            }
        }
    }
}
