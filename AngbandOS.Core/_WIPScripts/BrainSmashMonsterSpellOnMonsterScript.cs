// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BrainSmashMonsterSpellOnMonsterScript : Script, IScriptMonsterMonster
{
    private BrainSmashMonsterSpellOnMonsterScript(Game game) : base(game) { }
    public void ExecuteScriptMonsterMonster(Monster monster, Monster target)
    {
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        bool playerIsBlind = Game.BlindnessTimer.Value != 0;
        bool seen = !playerIsBlind && monster.IsVisible;
        string targetName = target.Name;
        bool blind = Game.BlindnessTimer.Value != 0;
        bool seeTarget = !blind && target.IsVisible;
        MonsterRace targetRace = target.Race;

        if (targetRace.Unique || targetRace.ImmuneConfusion ||
            targetRace.Level > base.Game.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
        {
            if (targetRace.ImmuneConfusion && seen)
            {
                targetRace.Knowledge.Characteristics.ImmuneConfusion = true;
            }
            if (seeTarget)
            {
                Game.MsgPrint($"{targetName} is unaffected!");
            }
        }
        else
        {
            if (seeTarget)
            {
                Game.MsgPrint($"{targetName} is blasted by psionic energy.");
            }
            target.ConfusionLevel += base.Game.RandomLessThan(4) + 4;
            target.Speed -= base.Game.RandomLessThan(4) + 4;
            target.StunLevel += base.Game.RandomLessThan(4) + 4;
            target.TakeDamageFromAnotherMonster(base.Game.DiceRoll(12, 15), out _, " collapses, a mindless husk.");
        }
    }
}
