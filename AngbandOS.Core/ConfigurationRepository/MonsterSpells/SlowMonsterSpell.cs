// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class SlowMonsterSpell : MonsterSpell
{
    private SlowMonsterSpell(SaveGame saveGame) : base(saveGame) { }
    public override bool IsIntelligent => true;
    public override bool RestrictsFreeAction => true;
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => $"Someone drains power from your muscles!";
    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} drains power from your muscles!";
    public override string? VsMonsterSeenMessage(Monster monster, Monster target)
    {
        string monsterName = target.Name;
        string targetName = target.Name;
        string it = (targetName == "it" ? "s" : "'s");
        return $"{monsterName} drains power from {targetName}{it} muscles.";
    }

    public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
    {
        string monsterName = monster.Name;

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
            saveGame.TimedSlow.AddTimer(SaveGame.Rng.RandomLessThan(4) + 4);
        }
        saveGame.UpdateSmartLearn(monster, SaveGame.SingletonRepository.SpellResistantDetections.Get(nameof(FreeSpellResistantDetection)));
    }

    public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
    {
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        bool blind = saveGame.TimedBlindness.TurnsRemaining != 0;
        bool seeTarget = !blind && target.IsVisible;
        MonsterRace targetRace = target.Race;
        string targetName = target.Name;

        if (targetRace.Unique)
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
            target.Speed -= 10;
            if (seeTarget)
            {
                saveGame.MsgPrint($"{targetName} starts moving slower.");
            }
        }
    }
}
