namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal abstract class CauseWoundsMonsterSpell : MonsterSpell
    {
        public override bool IsAttack => true;
        public override bool Annoys => true;

        public override string? VsPlayerBlindMessage => "You hear someone mumble.";

        public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} points at you and curses.";

        public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} points at {target.Name} and curses.";

        /// <summary>
        /// Returns the amount of damage inflicted.
        /// </summary>
        protected abstract int Damage { get; }

        /// <summary>
        /// Returns the chance that an item of equipment that the player is wearing will be cursed.
        /// </summary>
        protected abstract int CurseEquipmentChance { get; }

        /// <summary>
        /// Returns the chance that an item of equipment that the player is wearing will be heavily cursed.
        /// </summary>
        protected abstract int HeavyCurseEquipmentChance { get; }

        /// <summary>
        /// Returns an additional amount of time the player will bleed.  Returns 0, by default.
        /// </summary>
        protected virtual int TimedBleeding => 0;
        public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
        {
            if (Program.Rng.RandomLessThan(100) < saveGame.Player.SkillSavingThrow)
            {
                saveGame.MsgPrint("You resist the effects!");
            }
            else
            {
                string monsterDescription = monster.IndefiniteVisibleName;

                saveGame.Player.CurseEquipment(CurseEquipmentChance, HeavyCurseEquipmentChance);
                saveGame.Player.TakeHit(Damage, monsterDescription);

                if (TimedBleeding > 0)
                {
                    saveGame.Player.SetTimedBleeding(saveGame.Player.TimedBleeding + TimedBleeding);
                }
            }
        }

        public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
        {
            int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            string targetName = target.Name;
            bool blind = saveGame.Player.TimedBlindness != 0;
            bool seeTarget = !blind && target.IsVisible;
            MonsterRace targetRace = target.Race;

            if (targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
            {
                if (seeTarget)
                {
                    saveGame.MsgPrint($"{targetName} resists!");
                }
            }
            else
            {
                target.TakeDamageFromAnotherMonster(saveGame, Damage, out _, " is destroyed.");
            }
        }
    }
}
