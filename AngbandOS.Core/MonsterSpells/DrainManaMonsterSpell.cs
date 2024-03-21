// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class DrainManaMonsterSpell : MonsterSpell
{
    private DrainManaMonsterSpell(Game game) : base(game) { }
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

    public override void ExecuteOnPlayer(Game game, Monster monster)
    {
        string monsterName = monster.Name;
        bool playerIsBlind = game.BlindnessTimer.Value != 0;
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        bool seenByPlayer = !playerIsBlind && monster.IsVisible;

        if (game.Mana.Value != 0)
        {
            game.MsgPrint($"{monsterName} draws psychic energy from you!");
            int r1 = (Game.DieRoll(monsterLevel) / 2) + 1;
            if (r1 >= game.Mana.Value)
            {
                r1 = game.Mana.Value;
                game.Mana.Value = 0;
                game.FractionalMana = 0;
            }
            else
            {
                game.Mana.Value -= r1;
            }
            if (monster.Health < monster.MaxHealth)
            {
                monster.Health += 6 * r1;
                if (monster.Health > monster.MaxHealth)
                {
                    monster.Health = monster.MaxHealth;
                }
                if (game.TrackedMonsterIndex == monster.GetMonsterIndex())
                {
                    Game.SingletonRepository.FlaggedActions.Get(nameof(RedrawMonsterHealthFlaggedAction)).Set();
                }
                if (seenByPlayer)
                {
                    game.MsgPrint($"{monsterName} appears healthier.");
                }
            }
        }
        game.UpdateSmartLearn(monster, Game.SingletonRepository.SpellResistantDetections.Get(nameof(ManaSpellResistantDetection)));
    }

    public override void ExecuteOnMonster(Game game, Monster monster, Monster target)
    {
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        bool playerIsBlind = game.BlindnessTimer.Value != 0;
        bool seen = !playerIsBlind && monster.IsVisible;
        string monsterName = monster.Name;
        string targetName = target.Name;
        bool blind = game.BlindnessTimer.Value != 0;
        bool seeTarget = !blind && target.IsVisible;
        bool seeBoth = seen && seeTarget;
        MonsterRace targetRace = target.Race;

        int r1 = (Game.DieRoll(rlev) / 2) + 1;
        if (monster.Health < monster.MaxHealth)
        {
            if (targetRace.Spells.Count == 0)
            {
                if (seeBoth)
                {
                    game.MsgPrint($"{targetName} is unaffected!");
                }
            }
            else
            {
                monster.Health += 6 * r1;
                if (monster.Health > monster.MaxHealth)
                {
                    monster.Health = monster.MaxHealth;
                }
                if (game.TrackedMonsterIndex == monster.GetMonsterIndex())
                {
                    Game.SingletonRepository.FlaggedActions.Get(nameof(RedrawMonsterHealthFlaggedAction)).Set();
                }
                if (seen)
                {
                    game.MsgPrint($"{monsterName} appears healthier.");
                }
            }
        }
    }
}
