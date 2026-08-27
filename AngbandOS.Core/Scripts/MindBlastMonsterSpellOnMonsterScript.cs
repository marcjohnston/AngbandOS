// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

internal class MindBlastMonsterSpellOnMonsterScript : Script, IScriptMonsterMonster
{
    private MindBlastMonsterSpellOnMonsterScript(Game game) : base(game) { }
    public void ExecuteScriptMonsterMonster(Monster monster, Monster target)
    {
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        bool playerIsBlind = Game.BlindnessTimer.Value != 0;
        bool seen = !playerIsBlind && monster.IsVisible;
        string monsterName = monster.Name;
        string targetName = target.Name;
        bool blind = Game.BlindnessTimer.Value != 0;
        MonsterRace targetRace = target.Race;

        if (targetRace.Unique || targetRace.ImmuneConfusion || targetRace.Level > base.Game.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
        {
            if (targetRace.ImmuneConfusion && seen)
            {
                targetRace.Knowledge.Characteristics.ImmuneConfusion = true;
            }
            if (!blind && target.IsVisible)
            {
                Game.MsgPrint($"{targetName} is unaffected!");
            }
        }
        else
        {
            Game.MsgPrint($"{targetName} is blasted by psionic energy.");
            target.ConfusionLevel += base.Game.RandomLessThan(4) + 4;
            target.TakeDamageFromAnotherMonster(base.Game.DiceRoll(8, 8), out _, " collapses, a mindless husk.");
        }
    }
}
