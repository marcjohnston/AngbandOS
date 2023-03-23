namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class HealMonsterSpell : MonsterSpell
    {
        public override bool IsIntelligent => true;
        public override bool Heals => true;

        public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} concentrates on {monster.PossessiveName} wounds.";

        public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
        {
            string monsterPossessive = monster.PossessiveName;
            string monsterName = monster.Name;
            bool playerIsBlind = saveGame.Player.TimedBlindness.TurnsRemaining != 0;
            int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            bool seenByPlayer = !playerIsBlind && monster.IsVisible;

            monster.Health += monsterLevel * 6;
            if (monster.Health >= monster.MaxHealth)
            {
                monster.Health = monster.MaxHealth;
                saveGame.MsgPrint(seenByPlayer ? $"{monsterName} looks completely healed!" : $"{monsterName} sounds completely healed!");
            }
            else
            {
                saveGame.MsgPrint(seenByPlayer ? $"{monsterName} looks healthier." : $"{monsterName} sounds healthier.");
            }
            if (saveGame.TrackedMonsterIndex == monster.GetMonsterIndex())
            {
                saveGame.RedrawHealthFlaggedAction.Set();
            }
            if (monster.FearLevel != 0)
            {
                monster.FearLevel = 0;
                saveGame.MsgPrint($"{monsterName} recovers {monsterPossessive} courage.");
            }
        }

        public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
        {
            int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            string monsterName = monster.Name;
            bool blind = saveGame.Player.TimedBlindness.TurnsRemaining != 0;
            bool seen = !blind && monster.IsVisible;

            monster.Health += rlev * 6;
            if (monster.Health >= monster.MaxHealth)
            {
                monster.Health = monster.MaxHealth;
                saveGame.MsgPrint(seen ? $"{monsterName} looks completely healed!" : $"{monsterName} sounds completely healed!");
            }
            else
            {
                saveGame.MsgPrint(seen ? $"{monsterName} looks healthier." : $"{monsterName} sounds healthier.");
            }
            if (saveGame.TrackedMonsterIndex == monster.GetMonsterIndex())
            {
                saveGame.RedrawHealthFlaggedAction.Set();
            }
            if (monster.FearLevel != 0)
            {
                monster.FearLevel = 0;
                if (seen)
                {
                    saveGame.MsgPrint($"{monsterName} recovers {monster.PossessiveName} courage.");
                }
            }
        }
    }
}
