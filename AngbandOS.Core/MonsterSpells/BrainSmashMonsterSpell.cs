// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class BrainSmashMonsterSpell : MonsterSpell
{
    private BrainSmashMonsterSpell(SaveGame saveGame) : base(saveGame) { }
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => "You feel something focusing on your mind.";

    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} looks deep into your eyes.";

    public override string? VsMonsterUnseenMessage => null;

    public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} gazes intently at {target.Name}";

    public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
    {
        bool playerIsBlind = saveGame.TimedBlindness.TurnsRemaining != 0;
        string monsterDescription = monster.IndefiniteVisibleName;

        if (Program.Rng.RandomLessThan(100) < saveGame.SkillSavingThrow)
        {
            saveGame.MsgPrint("You resist the effects!");
        }
        else
        {
            saveGame.MsgPrint("Your mind is blasted by psionic energy.");
            saveGame.TakeHit(Program.Rng.DiceRoll(12, 15), monsterDescription);
            if (!saveGame.HasBlindnessResistance)
            {
                saveGame.TimedBlindness.AddTimer(8 + Program.Rng.RandomLessThan(8));
            }
            if (!saveGame.HasConfusionResistance)
            {
                saveGame.TimedConfusion.AddTimer(Program.Rng.RandomLessThan(4) + 4);
            }
            if (!saveGame.HasFreeAction)
            {
                saveGame.TimedParalysis.AddTimer(Program.Rng.RandomLessThan(4) + 4);
            }
            saveGame.TimedSlow.AddTimer(Program.Rng.RandomLessThan(4) + 4);
            while (Program.Rng.RandomLessThan(100) > saveGame.SkillSavingThrow)
            {
                saveGame.TryDecreasingAbilityScore(Ability.Intelligence);
            }
            while (Program.Rng.RandomLessThan(100) > saveGame.SkillSavingThrow)
            {
                saveGame.TryDecreasingAbilityScore(Ability.Wisdom);
            }
            if (!saveGame.HasChaosResistance)
            {
                saveGame.TimedHallucinations.AddTimer(Program.Rng.RandomLessThan(250) + 150);
            }
        }
    }
    public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
    {
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        bool playerIsBlind = saveGame.TimedBlindness.TurnsRemaining != 0;
        bool seen = !playerIsBlind && monster.IsVisible;
        string targetName = target.Name;
        bool blind = saveGame.TimedBlindness.TurnsRemaining != 0;
        bool seeTarget = !blind && target.IsVisible;
        MonsterRace targetRace = target.Race;

        if (targetRace.Unique || targetRace.ImmuneConfusion ||
            targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
        {
            if (targetRace.ImmuneConfusion && seen)
            {
                targetRace.Knowledge.Characteristics.ImmuneConfusion = true;
            }
            if (seeTarget)
            {
                saveGame.MsgPrint($"{targetName} is unaffected!");
            }
        }
        else
        {
            if (seeTarget)
            {
                saveGame.MsgPrint($"{targetName} is blasted by psionic energy.");
            }
            target.ConfusionLevel += Program.Rng.RandomLessThan(4) + 4;
            target.Speed -= Program.Rng.RandomLessThan(4) + 4;
            target.StunLevel += Program.Rng.RandomLessThan(4) + 4;
            target.TakeDamageFromAnotherMonster(saveGame, Program.Rng.DiceRoll(12, 15), out _, " collapses, a mindless husk.");
        }
    }
}
