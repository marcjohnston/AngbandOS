// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class HoldMonsterSpell : MonsterSpell
{
    private HoldMonsterSpell(SaveGame saveGame) : base(saveGame) { }
    public override bool IsIntelligent => true;
    public override bool RestrictsFreeAction => true;
    public override bool Annoys => true;

    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} stares deep into your eyes!";
    public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} stares intently at {target.Name}";

    public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
    {
        if (saveGame.HasFreeAction)
        {
            saveGame.MsgPrint("You are unaffected!");
        }
        else if (SaveGame.Rng.RandomLessThan(100) < saveGame.SkillSavingThrow)
        {
            saveGame.MsgPrint("You resist the effects!");
        }
        else
        {
            saveGame.TimedParalysis.AddTimer(SaveGame.Rng.RandomLessThan(4) + 4);
        }
        saveGame.UpdateSmartLearn(monster, SaveGame.SingletonRepository.SpellResistantDetections.Get(nameof(FreeSpellResistantDetection)));
    }

    public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
    {
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        string targetName = target.Name;
        bool blind = saveGame.TimedBlindness.TurnsRemaining != 0;
        bool seeTarget = !blind && target.IsVisible;
        MonsterRace targetRace = target.Race;

        if (targetRace.Unique || targetRace.ImmuneStun)
        {
            if (seeTarget)
            {
                saveGame.MsgPrint($"{targetName} is unaffected.");
            }
        }
        else if (targetRace.Level > SaveGame.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
        {
            if (seeTarget)
            {
                saveGame.MsgPrint($"{targetName} is unaffected.");
            }
        }
        else
        {
            target.StunLevel += SaveGame.Rng.DieRoll(4) + 4;
            if (seeTarget)
            {
                saveGame.MsgPrint($"{targetName} is paralyzed!");
            }
        }
    }
}
