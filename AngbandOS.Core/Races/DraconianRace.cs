namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class DraconianRace : Race
    {
        private DraconianRace(SaveGame saveGame) : base(saveGame) { }
        public override string Title => "Draconian";
        public override int[] AbilityBonus => new int[] { 2, 1, 1, 1, 2, -3 };
        public override int BaseDisarmBonus => -2;
        public override int BaseDeviceBonus => 5;
        public override int BaseSaveBonus => 3;
        public override int BaseStealthBonus => 0;
        public override int BaseSearchBonus => 1;
        public override int BaseSearchFrequency => 10;
        public override int BaseMeleeAttackBonus => 5;
        public override int BaseRangedAttackBonus => 5;
        public override int HitDieBonus => 11;
        public override int ExperienceFactor => 250;
        public override int BaseAge => 75;
        public override int AgeRange => 33;
        public override int MaleBaseHeight => 76;
        public override int MaleHeightRange => 1;
        public override int MaleBaseWeight => 160;
        public override int MaleWeightRange => 5;
        public override int FemaleBaseHeight => 72;
        public override int FemaleHeightRange => 1;
        public override int FemaleBaseWeight => 130;
        public override int FemaleWeightRange => 5;
        public override int Infravision => 2;
        public override uint Choice => 0xDF57;
        public override string Description => "Draconians are related to dragons and this shows both in\ntheir physical superiority and their legendary arrogance.\nAs well as having a breath weapon, their wings let them\navoid falling damage, and they can learn to resist fire\n(at lvl 5), cold (at lvl 10), acid (at lvl 15), lightning\n(at lvl 20), and poison (at lvl 35).";

        /// <summary>
        /// Draconian 89->90->91->End
        /// </summary>
        public override int Chart => 89;

        public override string RacialPowersDescription(int lvl) => "breath weapon      (racial, cost lvl, dam 2*lvl, CON based)";
        public override bool HasRacialPowers => true;

        public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
        {
            itemCharacteristics.Feather = true;
            if (level > 4)
            {
                itemCharacteristics.ResFire = true;
            }
            if (level > 9)
            {
                itemCharacteristics.ResCold = true;
            }
            if (level > 14)
            {
                itemCharacteristics.ResAcid = true;
            }
            if (level > 19)
            {
                itemCharacteristics.ResElec = true;
            }
            if (level > 34)
            {
                itemCharacteristics.ResPois = true;
            }
        }
        public override string CreateRandomName() => CreateRandomNameFromSyllables(new GnomishSyllables());
        public override string[]? SelfKnowledge(int level)
        {
            return new string[] { $"You can breathe, dam. {2 * level} (cost {level})." };
        }
        public override void CalcBonuses(SaveGame saveGame)
        {
            saveGame.Player.HasFeatherFall = true;
            if (saveGame.Player.Level > 4)
            {
                saveGame.Player.HasFireResistance = true;
            }
            if (saveGame.Player.Level > 9)
            {
                saveGame.Player.HasColdResistance = true;
            }
            if (saveGame.Player.Level > 14)
            {
                saveGame.Player.HasAcidResistance = true;
            }
            if (saveGame.Player.Level > 19)
            {
                saveGame.Player.HasLightningResistance = true;
            }
            if (saveGame.Player.Level > 34)
            {
                saveGame.Player.HasPoisonResistance = true;
            }
        }

        public override void UseRacialPower(SaveGame saveGame)
        {
            // Draconians can breathe an element based on their class and level
            Projectile projectile;
            string projectileDescription;

            // Default to being randomly fire (66% chance) or cold (33% chance)
            if (Program.Rng.DieRoll(3) == 1)
            {
                projectile = new ProjectCold(saveGame);
                projectileDescription = "cold";
            }
            else
            {
                projectile = new ProjectFire(saveGame);
                projectileDescription = "fire";
            }

            // Chance of replacing the default fire/cold element with a special one
            if (Program.Rng.DieRoll(100) < saveGame.Player.Level)
            {
                switch (saveGame.Player.BaseCharacterClass.ID)
                {
                    case CharacterClass.Warrior:
                    case CharacterClass.Ranger:
                    case CharacterClass.Druid:
                    case CharacterClass.ChosenOne:
                        if (Program.Rng.DieRoll(3) == 1)
                        {
                            projectile = new ProjectMissile(saveGame);
                            projectileDescription = "the elements";
                        }
                        else
                        {
                            projectile = new ProjectExplode(saveGame);
                            projectileDescription = "shards";
                        }
                        break;

                    case CharacterClass.Mage:
                    case CharacterClass.WarriorMage:
                    case CharacterClass.HighMage:
                    case CharacterClass.Channeler:
                        if (Program.Rng.DieRoll(3) == 1)
                        {
                            projectile = new ProjectMana(saveGame);
                            projectileDescription = "mana";
                        }
                        else
                        {
                            projectile = new ProjectDisenchant(saveGame);
                            projectileDescription = "disenchantment";
                        }
                        break;

                    case CharacterClass.Fanatic:
                    case CharacterClass.Cultist:
                        if (Program.Rng.DieRoll(3) != 1)
                        {
                            projectile = new ProjectConfusion(saveGame);
                            projectileDescription = "confusion";
                        }
                        else
                        {
                            projectile = new ProjectChaos(saveGame);
                            projectileDescription = "chaos";
                        }
                        break;

                    case CharacterClass.Monk:
                        if (Program.Rng.DieRoll(3) != 1)
                        {
                            projectile = new ProjectConfusion(saveGame);
                            projectileDescription = "confusion";
                        }
                        else
                        {
                            projectile = new ProjectSound(saveGame);
                            projectileDescription = "sound";
                        }
                        break;

                    case CharacterClass.Mindcrafter:
                    case CharacterClass.Mystic:
                        if (Program.Rng.DieRoll(3) != 1)
                        {
                            projectile = new ProjectConfusion(saveGame);
                            projectileDescription = "confusion";
                        }
                        else
                        {
                            projectile = new ProjectPsi(saveGame);
                            projectileDescription = "mental energy";
                        }
                        break;

                    case CharacterClass.Priest:
                    case CharacterClass.Paladin:
                        if (Program.Rng.DieRoll(3) == 1)
                        {
                            projectile = new ProjectHellFire(saveGame);
                            projectileDescription = "hellfire";
                        }
                        else
                        {
                            projectile = new ProjectHolyFire(saveGame);
                            projectileDescription = "holy fire";
                        }
                        break;

                    case CharacterClass.Rogue:
                        if (Program.Rng.DieRoll(3) == 1)
                        {
                            projectile = new ProjectDark(saveGame);
                            projectileDescription = "darkness";
                        }
                        else
                        {
                            projectile = new ProjectPois(saveGame);
                            projectileDescription = "poison";
                        }
                        break;
                }
            }
            if (saveGame.CheckIfRacialPowerWorks(1, saveGame.Player.Level, Ability.Constitution, 12))
            {
                if (saveGame.GetDirectionWithAim(out int direction))
                {
                    saveGame.MsgPrint($"You breathe {projectileDescription}.");
                    saveGame.FireBall(projectile, direction, saveGame.Player.Level * 2, -(saveGame.Player.Level / 15) + 1);
                }
            }
        }
    }
}