﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class DrainManaMonsterSpell : MonsterSpell
{
    private DrainManaMonsterSpell(SaveGame saveGame) : base(saveGame) { }
    /// <summary>
    /// Returns null, because the drain mana process cannot be seen.  If the player cannot see either monster, the player will not have
    /// any message indicating such.
    /// </summary>
    public override string? VsPlayerBlindMessage => null;

    /// <summary>
    /// Returns null, because the drain mana process cannot be seen.  If the player cannot see either monster, the player will not have
    /// any message indicating such.
    /// </summary>
    public override string? VsPlayerActionMessage(Monster monster) => null;

    /// <summary>
    /// Returns the message rendered to the player when a monster drains energy from another monster and the player sees it.
    /// </summary>
    public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} draws psychic energy from {target.Name}.";

    public override bool DrainsMana => true;
    public override bool Annoys => true;

    public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
    {
        string monsterName = monster.Name;
        bool playerIsBlind = saveGame.TimedBlindness.TurnsRemaining != 0;
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        bool seenByPlayer = !playerIsBlind && monster.IsVisible;

        if (saveGame.Mana != 0)
        {
            saveGame.MsgPrint($"{monsterName} draws psychic energy from you!");
            int r1 = (SaveGame.Rng.DieRoll(monsterLevel) / 2) + 1;
            if (r1 >= saveGame.Mana)
            {
                r1 = saveGame.Mana;
                saveGame.Mana = 0;
                saveGame.FractionalMana = 0;
            }
            else
            {
                saveGame.Mana -= r1;
            }
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawManaFlaggedAction>().Set();
            if (monster.Health < monster.MaxHealth)
            {
                monster.Health += 6 * r1;
                if (monster.Health > monster.MaxHealth)
                {
                    monster.Health = monster.MaxHealth;
                }
                if (saveGame.TrackedMonsterIndex == monster.GetMonsterIndex())
                {
                    SaveGame.SingletonRepository.FlaggedActions.Get<RedrawHealthFlaggedAction>().Set();
                }
                if (seenByPlayer)
                {
                    saveGame.MsgPrint($"{monsterName} appears healthier.");
                }
            }
        }
        saveGame.UpdateSmartLearn(monster, SaveGame.SingletonRepository.SpellResistantDetections.Get<ManaSpellResistantDetection>());
    }

    public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
    {
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        bool playerIsBlind = saveGame.TimedBlindness.TurnsRemaining != 0;
        bool seen = !playerIsBlind && monster.IsVisible;
        string monsterName = monster.Name;
        string targetName = target.Name;
        bool blind = saveGame.TimedBlindness.TurnsRemaining != 0;
        bool seeTarget = !blind && target.IsVisible;
        bool seeBoth = seen && seeTarget;
        MonsterRace targetRace = target.Race;

        int r1 = (SaveGame.Rng.DieRoll(rlev) / 2) + 1;
        if (monster.Health < monster.MaxHealth)
        {
            if (targetRace.Spells.Count == 0)
            {
                if (seeBoth)
                {
                    saveGame.MsgPrint($"{targetName} is unaffected!");
                }
            }
            else
            {
                monster.Health += 6 * r1;
                if (monster.Health > monster.MaxHealth)
                {
                    monster.Health = monster.MaxHealth;
                }
                if (saveGame.TrackedMonsterIndex == monster.GetMonsterIndex())
                {
                    SaveGame.SingletonRepository.FlaggedActions.Get<RedrawHealthFlaggedAction>().Set();
                }
                if (seen)
                {
                    saveGame.MsgPrint($"{monsterName} appears healthier.");
                }
            }
        }
    }
}