﻿using AngbandOS.Core.MonsterRaces;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class DreadCurseMonsterSpell : MonsterSpell
    {
        public override bool IsAttack => true;
        public override string? VsPlayerBlindMessage => "You hear someone invoke the Dread Curse of Azathoth!";
        public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} invokes the Dread Curse of Azathoth!";
        public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} invokes the Dread Curse of Azathoth on {target.Name}";

        public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
        {
            if (Program.Rng.RandomLessThan(100) < saveGame.Player.SkillSavingThrow)
            {
                saveGame.MsgPrint("You resist the effects!");
            }
            else
            {
                int dummy = (65 + Program.Rng.DieRoll(25)) * saveGame.Player.Health / 100;
                saveGame.MsgPrint("Your feel your life fade away!");
                saveGame.Player.TakeHit(dummy, monster.Name);
                saveGame.Player.CurseEquipment(100, 20);
                if (saveGame.Player.Health < 1)
                {
                    saveGame.Player.Health = 1;
                }
            }
        }

        public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
        {
            string targetName = target.Name;
            bool blind = saveGame.Player.TimedBlindness != 0;
            bool seeTarget = !blind && target.IsVisible;
            MonsterRace targetRace = target.Race;

            if (targetRace.Unique)
            {
                if (!blind && seeTarget)
                {
                    saveGame.MsgPrint($"{targetName} is unaffected!");
                }
            }
            else
            {
                if (monster.Race.Level + Program.Rng.DieRoll(20) > targetRace.Level + 10 + Program.Rng.DieRoll(20))
                {
                    target.Health -= (65 + Program.Rng.DieRoll(25)) * target.Health / 100;
                    if (target.Health < 1)
                    {
                        target.Health = 1;
                    }
                }
                else
                {
                    if (seeTarget)
                    {
                        saveGame.MsgPrint($"{targetName} resists!");
                    }
                }
            }
        }
    }
}