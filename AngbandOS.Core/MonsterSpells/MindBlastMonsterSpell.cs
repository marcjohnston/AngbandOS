// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class MindBlastMonsterSpell : MonsterSpell
{
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => "You feel something focusing on your mind.";

    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} gazes deep into your eyes.";

    /// <summary>
    /// Returns null, because a blind player will not be aware this action is taking place.
    /// </summary>
    public override string? VsMonsterUnseenMessage => null;

    public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} gazes intently at {target.Name}";

    public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
    {
        if (Program.Rng.RandomLessThan(100) < saveGame.SkillSavingThrow)
        {
            saveGame.MsgPrint("You resist the effects!");
        }
        else
        {
            saveGame.MsgPrint("Your mind is blasted by psionic energy.");
            if (!saveGame.HasConfusionResistance)
            {
                saveGame.TimedConfusion.AddTimer(Program.Rng.RandomLessThan(4) + 4);
            }
            if (!saveGame.HasChaosResistance && Program.Rng.DieRoll(3) == 1)
            {
                saveGame.TimedHallucinations.AddTimer(Program.Rng.RandomLessThan(250) + 150);
            }

            string monsterDescription = monster.IndefiniteVisibleName;
            saveGame.TakeHit(Program.Rng.DiceRoll(8, 8), monsterDescription);
        }
    }

    public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
    {
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        bool playerIsBlind = saveGame.TimedBlindness.TurnsRemaining != 0;
        bool seen = !playerIsBlind && monster.IsVisible;
        string monsterName = monster.Name;
        string targetName = target.Name;
        bool blind = saveGame.TimedBlindness.TurnsRemaining != 0;
        MonsterRace targetRace = target.Race;

        if (targetRace.Unique || targetRace.ImmuneConfusion || targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
        {
            if (targetRace.ImmuneConfusion && seen)
            {
                targetRace.Knowledge.Characteristics.ImmuneConfusion = true;
            }
            if (!blind && target.IsVisible)
            {
                saveGame.MsgPrint($"{targetName} is unaffected!");
            }
        }
        else
        {
            saveGame.MsgPrint($"{targetName} is blasted by psionic energy.");
            target.ConfusionLevel += Program.Rng.RandomLessThan(4) + 4;
            target.TakeDamageFromAnotherMonster(saveGame, Program.Rng.DiceRoll(8, 8), out _, " collapses, a mindless husk.");
        }
    }
}