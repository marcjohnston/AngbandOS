// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

internal class MindBlastMonsterSpellOnPlayerScript : Script, IScriptMonster
{
    private MindBlastMonsterSpellOnPlayerScript(Game game) : base(game) { }
    public void ExecuteScriptMonster(Monster monster)
    {
        if (base.Game.RandomLessThan(100) < Game.SkillSavingThrow)
        {
            Game.MsgPrint("You resist the effects!");
        }
        else
        {
            Game.MsgPrint("Your mind is blasted by psionic energy.");
            if (!Game.HasConfusionResistance)
            {
                Game.ConfusionTimer.AddTimer(base.Game.RandomLessThan(4) + 4);
            }
            if (!Game.HasChaosResistance && base.Game.DieRoll(3) == 1)
            {
                Game.HallucinationsTimer.AddTimer(base.Game.RandomLessThan(250) + 150);
            }

            string monsterDescription = monster.IndefiniteVisibleName;
            Game.TakeHit(base.Game.DiceRoll(8, 8), monsterDescription);
        }
    }
}
