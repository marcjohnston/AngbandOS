// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class HealMonsterSpell : MonsterSpell
{
    private HealMonsterSpell(Game game) : base(game) { }
    public override bool IsIntelligent => true;
    public override bool Heals => true;

    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} concentrates on {monster.PossessiveName} wounds.";

    public override void ExecuteOnPlayer(Monster monster)
    {
        string monsterPossessive = monster.PossessiveName;
        string monsterName = monster.Name;
        bool playerIsBlind = Game.BlindnessTimer.Value != 0;
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        bool seenByPlayer = !playerIsBlind && monster.IsVisible;

        monster.Health += monsterLevel * 6;
        if (monster.Health >= monster.MaxHealth)
        {
            monster.Health = monster.MaxHealth;
            Game.MsgPrint(seenByPlayer ? $"{monsterName} looks completely healed!" : $"{monsterName} sounds completely healed!");
        }
        else
        {
            Game.MsgPrint(seenByPlayer ? $"{monsterName} looks healthier." : $"{monsterName} sounds healthier.");
        }
        if (Game.TrackedMonsterIndex != null && Game.TrackedMonsterIndex.Value == monster.GetMonsterIndex())
        {
            Game.SingletonRepository.FlaggedActions.Get(nameof(RedrawMonsterHealthFlaggedAction)).Set();
        }
        if (monster.FearLevel != 0)
        {
            monster.FearLevel = 0;
            Game.MsgPrint($"{monsterName} recovers {monsterPossessive} courage.");
        }
    }

    public override void ExecuteOnMonster(Monster monster, Monster target)
    {
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        string monsterName = monster.Name;
        bool blind = Game.BlindnessTimer.Value != 0;
        bool seen = !blind && monster.IsVisible;

        monster.Health += rlev * 6;
        if (monster.Health >= monster.MaxHealth)
        {
            monster.Health = monster.MaxHealth;
            Game.MsgPrint(seen ? $"{monsterName} looks completely healed!" : $"{monsterName} sounds completely healed!");
        }
        else
        {
            Game.MsgPrint(seen ? $"{monsterName} looks healthier." : $"{monsterName} sounds healthier.");
        }
        if (Game.TrackedMonsterIndex != null && Game.TrackedMonsterIndex.Value == monster.GetMonsterIndex())
        {
            base.Game.SingletonRepository.FlaggedActions.Get(nameof(FlaggedActions.RedrawMonsterHealthFlaggedAction)).Set();
        }
        if (monster.FearLevel != 0)
        {
            monster.FearLevel = 0;
            if (seen)
            {
                Game.MsgPrint($"{monsterName} recovers {monster.PossessiveName} courage.");
            }
        }
    }
}
