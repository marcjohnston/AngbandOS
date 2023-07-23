// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class ScareMonsterSpell : MonsterSpell
{
    private ScareMonsterSpell(SaveGame saveGame) : base(saveGame) { }
    public override bool IsIntelligent => true;
    public override bool UsesFear => true;
    public override bool IsAttack => true;
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => $"Someone mumbles, and you hear scary noises.";

    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} casts a fearful illusion.";

    public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} casts a fearful illusion at {target.Name}";

    public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
    {
        if (saveGame.HasFearResistance)
        {
            saveGame.MsgPrint("You refuse to be frightened.");
        }
        else if (Program.Rng.RandomLessThan(100) < saveGame.SkillSavingThrow)
        {
            saveGame.MsgPrint("You refuse to be frightened.");
        }
        else
        {
            saveGame.TimedFear.AddTimer(Program.Rng.RandomLessThan(4) + 4);
        }
        saveGame.UpdateSmartLearn(monster, SaveGame.SingletonRepository.SpellResistantDetections.Get<FearSpellResistantDetection>());
    }

    public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
    {
        MonsterRace targetRace = target.Race;
        bool playerIsBlind = saveGame.TimedBlindness.TurnsRemaining != 0;
        bool seeTarget = !playerIsBlind && target.IsVisible;
        string targetName = target.Name;
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;

        if (targetRace.ImmuneFear)
        {
            if (seeTarget)
            {
                saveGame.MsgPrint($"{targetName} refuses to be frightened.");
            }
        }
        else if (targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
        {
            if (seeTarget)
            {
                saveGame.MsgPrint($"{targetName} refuses to be frightened.");
            }
        }
        else
        {
            if (target.FearLevel == 0 && seeTarget)
            {
                saveGame.MsgPrint($"{targetName} flees in terror!");
            }
            target.FearLevel += Program.Rng.RandomLessThan(4) + 4;
        }

        // Most spells will wake up the target if it's asleep
        target.SleepLevel = 0;
    }
}
