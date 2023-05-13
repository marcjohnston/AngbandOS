namespace AngbandOS.Core
{
    [Serializable]
    internal class Player
    {
        public readonly AbilityScore[] AbilityScores = new AbilityScore[6];
        public readonly Genome Dna;
        public readonly string[] History = new string[4];
        public readonly int[] MaxDlv = new int[Constants.MaxCaves];
        public readonly int[] PlayerHp = new int[Constants.PyMaxLevel];
        public int Age;
        public ItemTypeEnum AmmunitionItemCategory; // TODO: This needs to be a property of the missileweaponitemcategory
        public int ArmourClassBonus;
        public int AttackBonus;
        public int BaseArmourClass;
        public int DamageBonus;
        public int DisplayedArmourClassBonus;
        public int DisplayedAttackBonus;
        public int DisplayedBaseArmourClass;
        public int DisplayedDamageBonus;
        public int Energy;
        public int ExperienceMultiplier;
        public int ExperiencePoints;
        public int Food;
        public int FractionalExperiencePoints;
        public int FractionalHealth;
        public int FractionalMana;
        public GameTime GameTime;
        public Gender Gender = new Gender();
        public int GenderIndex;
        public int Generation; // This is how many times the character name has changed.
        public bool GetFirstLevelMutation;
        private int _gold;
        public int Gold
        {
            get
            {
                return _gold;
            }
            set
            {
                _gold = value;
                SaveGame.UpdateNotifier?.GoldUpdated(_gold);
            }
        }
        public Patron GooPatron;
        public bool HasAcidImmunity;
        public bool HasAcidResistance;
        public bool HasAggravation;
        public bool HasAntiMagic;
        public bool HasAntiTeleport;
        public bool HasAntiTheft;
        public bool HasBlessedBlade;
        public bool HasBlindnessResistance;
        public bool HasChaosResistance;
        public bool HasColdImmunity;
        public bool HasColdResistance;
        public bool HasConfusingTouch;
        public bool HasConfusionResistance;
        public bool HasDarkResistance;
        public bool HasDisenchantResistance;
        public bool HasElementalVulnerability;
        public bool HasExperienceDrain;
        public bool HasExtraMight;
        public bool HasFearResistance;
        public bool HasFeatherFall;
        public bool HasFireImmunity;
        public bool HasFireResistance;
        public bool HasFireShield;
        public bool HasFreeAction;
        public bool HasGlow;
        public bool HasHeavyBow;
        public bool HasHeavyWeapon;
        public bool HasHoldLife;
        public bool HasLightningImmunity;
        public bool HasLightningResistance;
        public bool HasLightningShield;
        public bool HasLightResistance;
        public bool HasNetherResistance;
        public bool HasNexusResistance;
        public bool HasPoisonResistance;
        public bool HasQuakeWeapon;
        public bool HasRandomTeleport;
        public bool HasReflection;
        public bool HasRegeneration;
        public bool HasRestrictingArmour;
        public bool HasRestrictingGloves;
        public bool HasSeeInvisibility;
        public bool HasShardResistance;
        public bool HasSlowDigestion;
        public bool HasSoundResistance;
        public bool HasSustainCharisma;
        public bool HasSustainConstitution;
        public bool HasSustainDexterity;
        public bool HasSustainIntelligence;
        public bool HasSustainStrength;
        public bool HasSustainWisdom;
        public bool HasTelepathy;
        public bool HasTimeResistance;
        public bool HasUnpriestlyWeapon;
        public int Health;
        public int Height;
        public int HitDie;
        public int InfravisionRange;
        public bool IsDead;
        public bool IsSearching;
        public bool IsWinner;
        public bool IsWizard;
        private int _level;
        public int Level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
                SaveGame.UpdateNotifier?.LevelChanged(_level);
            }
        }

        public int LightLevel;
        public int Mana;
        public int MapX;
        public int MapY;
        public int MaxExperienceGained;
        public int MaxHealth;
        public int MaxLevelGained;
        public int MaxMana;
        public int MeleeAttacksPerRound;
        public int MissileAttacksPerRound;
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                SaveGame.UpdateNotifier?.CharacterRenamed(_name);
            }
        }
        public int OldSpareSpellSlots;

        /// <summary>
        /// Represents the character class of the player.  Will be null prior to the character class birth selection.
        /// </summary>
        public BaseCharacterClass? BaseCharacterClass = null;

        /// <summary>
        /// Returns the current race of the character.  Will be null before the player is birthed.
        /// </summary>
        public Race? Race = null;

        /// <summary>
        /// Returns the race the character was first assigned at birth.
        /// </summary>
        public Race RaceAtBirth;

        /// <summary>
        /// Returns the primary realm that the player studies.
        /// </summary>
        /// <value>The realm1.</value>
        public BaseRealm? PrimaryRealm = null;

        /// <summary>
        /// Returns the secondary realm that the player studies.
        /// </summary>
        /// <value>The realm2.</value>
        public BaseRealm? SecondaryRealm = null;

        /// <summary>
        /// Returns true, if the player can cast spells and/or read books.  True, for character classes that can choose either a primary and/or secondary realm.
        /// </summary>
        public bool CanCastSpells => PrimaryRealm != null || SecondaryRealm != null;

        /// <summary>
        /// Returns true, if the player has chosen the realm <T> for either the primary or secondary realms to study.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool Studies<T>() where T : BaseRealm => (PrimaryRealm != null && typeof(T).IsAssignableFrom(PrimaryRealm.GetType())) || (SecondaryRealm != null && typeof(T).IsAssignableFrom(SecondaryRealm.GetType()));

        public Religion Religion = new Religion();
        public int SkillDigging;
        public int SkillDisarmTraps;
        public int SkillMelee;
        public int SkillRanged;
        public int SkillSavingThrow;
        public int SkillSearchFrequency;
        public int SkillSearching;
        public int SkillStealth;
        public int SkillThrowing;
        public int SkillUseDevice;
        public int SocialClass;
        public int SpareSpellSlots;
        public int Speed;
        public TimedAction TimedAcidResistance;
        public TimedAction TimedBleeding;
        public TimedAction TimedBlessing;
        public TimedAction TimedBlindness;
        public TimedAction TimedColdResistance;
        public TimedAction TimedConfusion;
        public TimedAction TimedEtherealness;
        public TimedAction TimedFear;
        public TimedAction TimedFireResistance;
        public TimedAction TimedHallucinations;
        public TimedAction TimedHaste;
        public TimedAction TimedHeroism;
        public TimedAction TimedInfravision;
        public TimedAction TimedInvulnerability;
        public TimedAction TimedLightningResistance;
        public TimedAction TimedParalysis;
        public TimedAction TimedPoison;
        public TimedAction TimedPoisonResistance;
        public TimedAction TimedProtectionFromEvil;
        public TimedAction TimedSeeInvisibility;
        public TimedAction TimedSlow;
        public TimedAction TimedStoneskin;
        public TimedAction TimedStun;
        public TimedAction TimedSuperheroism;
        public TimedAction TimedTelepathy;
        public int TownWithHouse;
        public int Weight;
        public int WeightCarried;
        public int WildernessX;
        public int WildernessY;
        public int WordOfRecallDelay;
        private readonly SaveGame SaveGame;

        public Player(SaveGame saveGame)
        {
            SaveGame = saveGame;
            TimedAcidResistance = new AcidResistanceTimedAction(saveGame);
            TimedBleeding = new BleedingTimedAction(saveGame);
            TimedBlessing = new BlessingTimedAction(saveGame);
            TimedBlindness = new BlindnessTimedAction(saveGame);
            TimedColdResistance = new ColdResistanceTimedAction(saveGame);
            TimedConfusion = new ConfusionTimedAction(saveGame);
            TimedEtherealness = new EtherealnessTimedAction(saveGame);
            TimedFear = new FearTimedAction(saveGame);
            TimedFireResistance = new FireResistanceTimedAction(saveGame);
            TimedHallucinations = new HallucinationsTimedAction(saveGame);
            TimedHaste = new HasteTimedAction(saveGame);
            TimedHeroism = new HeroismTimedAction(saveGame);
            TimedInfravision = new InfravisionTimedAction(saveGame);
            TimedInvulnerability = new InvulnerabilityTimedAction(saveGame);
            TimedLightningResistance = new LightningResistanceTimedAction(saveGame);
            TimedParalysis = new ParalysisTimedAction(saveGame);
            TimedPoison = new PoisonTimedAction(saveGame);
            TimedPoisonResistance = new PoisonResistanceTimedAction(saveGame);
            TimedProtectionFromEvil = new ProtectionFromEvilTimedAction(saveGame);
            TimedSeeInvisibility = new SeeInvisibilityTimedAction(saveGame);
            TimedSlow = new SlowTimedAction(saveGame);
            TimedStoneskin = new StoneskinTimedAction(saveGame);
            TimedStun = new StunTimedAction(saveGame);
            TimedSuperheroism = new SuperHeroismTimedAction(saveGame);
            TimedTelepathy = new TelepathyTimedAction(saveGame);
            Dna = new Genome(SaveGame);
            for (int i = 0; i < 4; i++)
            {
                History[i] = "";
            }
            for (int i = 0; i < 6; i++)
            {
                AbilityScores[i] = new AbilityScore();
            }
            WeightCarried = 0;

            foreach (FixedArtifact aPtr in SaveGame.SingletonRepository.FixedArtifacts)
            {
                aPtr.CurNum = 0;
            }
            foreach (ItemFactory kPtr in SaveGame.SingletonRepository.ItemFactories)
            {
                kPtr.Tried = false;
                kPtr.FlavourAware = false;
            }
            for (int i = 1; i < SaveGame.SingletonRepository.MonsterRaces.Count; i++)
            {
                MonsterRace rPtr = SaveGame.SingletonRepository.MonsterRaces[i];
                rPtr.CurNum = 0;
                rPtr.MaxNum = 100;
                if (rPtr.Unique)
                {
                    rPtr.MaxNum = 1;
                }
                rPtr.Knowledge.RPkills = 0;
            }
            SaveGame.SingletonRepository.MonsterRaces[SaveGame.SingletonRepository.MonsterRaces.Count - 1].MaxNum = 0;
            Food = Constants.PyFoodFull - 1;
            IsWizard = false;
            IsWinner = false;
            TownWithHouse = -1;
            Generation = 1;
        }

        public void RecenterScreenAroundPlayer()
        {
            int y = MapY;
            int x = MapX;
            int maxProwMin = SaveGame.Level.MaxPanelRows * (Constants.ScreenHgt / 2);
            int maxPcolMin = SaveGame.Level.MaxPanelCols * (Constants.ScreenWid / 2);
            int prowMin = y - (Constants.ScreenHgt / 2);
            if (prowMin > maxProwMin)
            {
                prowMin = maxProwMin;
            }
            else if (prowMin < 0)
            {
                prowMin = 0;
            }
            int pcolMin = x - (Constants.ScreenWid / 2);
            if (pcolMin > maxPcolMin)
            {
                pcolMin = maxPcolMin;
            }
            else if (pcolMin < 0)
            {
                pcolMin = 0;
            }
            if (prowMin == SaveGame.Level.PanelRowMin && pcolMin == SaveGame.Level.PanelColMin)
            {
                return;
            }
            SaveGame.Level.PanelRowMin = prowMin;
            SaveGame.Level.PanelColMin = pcolMin;
            SaveGame.Level.PanelBoundsCenter();
            SaveGame.UpdateMonstersFlaggedAction.Set();
            SaveGame.RedrawMapFlaggedAction.Set();
        }

        public void ChangeRace(Race newRace)
        {
            Race = newRace;
            ExperienceMultiplier = Race.ExperienceFactor + BaseCharacterClass.ExperienceFactor;
            if (GenderIndex == Constants.SexMale)
            {
                Height = Program.Rng.RandomNormal(Race.MaleBaseHeight, Race.MaleHeightRange);
                Weight = Program.Rng.RandomNormal(Race.MaleBaseWeight, Race.MaleWeightRange);
            }
            else if (GenderIndex == Constants.SexFemale)
            {
                Height = Program.Rng.RandomNormal(Race.FemaleBaseHeight, Race.FemaleHeightRange);
                Weight = Program.Rng.RandomNormal(Race.FemaleBaseWeight, Race.FemaleWeightRange);
            }
            else
            {
                if (Program.Rng.DieRoll(2) == 1)
                {
                    Height = Program.Rng.RandomNormal(Race.MaleBaseHeight, Race.MaleHeightRange);
                    Weight = Program.Rng.RandomNormal(Race.MaleBaseWeight, Race.MaleWeightRange);
                }
                else
                {
                    Height = Program.Rng.RandomNormal(Race.FemaleBaseHeight, Race.FemaleHeightRange);
                    Weight = Program.Rng.RandomNormal(Race.FemaleBaseWeight, Race.FemaleWeightRange);
                }
            }
            CheckExperience();
            MaxLevelGained = Level;
            SaveGame.PrBasicRedrawAction.Set();
            SaveGame.UpdateBonusesFlaggedAction.Set();
            SaveGame.HandleStuff();
        }

        public void CheckExperience()
        {
            bool levelReward = false;
            bool levelMutation = false;
            if (ExperiencePoints < 0)
            {
                ExperiencePoints = 0;
            }
            if (MaxExperienceGained < 0)
            {
                MaxExperienceGained = 0;
            }
            if (ExperiencePoints > Constants.PyMaxExp)
            {
                ExperiencePoints = Constants.PyMaxExp;
            }
            if (MaxExperienceGained > Constants.PyMaxExp)
            {
                MaxExperienceGained = Constants.PyMaxExp;
            }
            if (ExperiencePoints > MaxExperienceGained)
            {
                MaxExperienceGained = ExperiencePoints;
            }
            SaveGame.RedrawExpFlaggedAction.Set();
            SaveGame.HandleStuff();
            while (Level > 1 && ExperiencePoints < Constants.PlayerExp[Level - 2] * ExperienceMultiplier / 100L)
            {
                Level--;
                SaveGame.Level.RedrawSingleLocation(MapY, MapX);
                SaveGame.UpdateHealthFlaggedAction.Set();
                SaveGame.UpdateManaFlaggedAction.Set();
                SaveGame.UpdateSpellsFlaggedAction.Set();
                SaveGame.UpdateBonusesFlaggedAction.Set();
                SaveGame.RedrawTitleFlaggedAction.Set();
                SaveGame.RedrawLevelFlaggedAction.Set();
                SaveGame.HandleStuff();
            }
            while (Level < Constants.PyMaxLevel && ExperiencePoints >= Constants.PlayerExp[Level - 1] * ExperienceMultiplier / 100L)
            {
                Level++;
                SaveGame.Level.RedrawSingleLocation(MapY, MapX);
                if (Level > MaxLevelGained)
                {
                    MaxLevelGained = Level;
                    if (BaseCharacterClass.ID == CharacterClass.Fanatic || BaseCharacterClass.ID == CharacterClass.Cultist)
                    {
                        levelReward = true;
                    }
                    if (Dna.ChaosGift)
                    {
                        levelReward = true;
                    }
                    if (Race.AutomaticallyGainsFirstLevelMutationAtBirth)
                    {
                        if (Program.Rng.DieRoll(5) == 1)
                        {
                            levelMutation = true;
                        }
                    }
                }
                SaveGame.PlaySound(SoundEffect.LevelGain);
                SaveGame.MsgPrint($"Welcome to level {Level}.");
                SaveGame.UpdateHealthFlaggedAction.Set();
                SaveGame.UpdateManaFlaggedAction.Set();
                SaveGame.UpdateSpellsFlaggedAction.Set();
                SaveGame.UpdateBonusesFlaggedAction.Set();
                SaveGame.RedrawTitleFlaggedAction.Set();
                SaveGame.RedrawLevelFlaggedAction.Set();
                SaveGame.RedrawExpFlaggedAction.Set();
                SaveGame.HandleStuff();
                if (levelReward)
                {
                    GainLevelReward();
                    levelReward = false;
                }
                if (levelMutation)
                {
                    SaveGame.MsgPrint("You feel different...");
                    Dna.GainMutation();
                    levelMutation = false;
                }
            }
        }

        public void CurseEquipment(int chance, int heavyChance)
        {
            bool changed = false;
            if (Program.Rng.DieRoll(100) > chance)
            {
                return;
            }
            Item? oPtr = SaveGame.GetInventoryItem(InventorySlot.MeleeWeapon - 1 + Program.Rng.DieRoll(12));
            if (oPtr == null)
            {
                return;
            }
            oPtr.RefreshFlagBasedProperties();
            if (oPtr.Characteristics.Blessed && Program.Rng.DieRoll(888) > chance)
            {
                string oName = oPtr.Description(false, 0);
                string s = oPtr.Count > 1 ? "" : "s";
                SaveGame.MsgPrint($"Your {oName} resist{s} cursing!");
                return;
            }
            if (Program.Rng.DieRoll(100) <= heavyChance && (oPtr.FixedArtifact != null || oPtr.RareItemTypeIndex != 0 || !string.IsNullOrEmpty(oPtr.RandartName)))
            {
                if (!oPtr.Characteristics.HeavyCurse)
                {
                    changed = true;
                }
                oPtr.RandartItemCharacteristics.HeavyCurse = true;
                oPtr.RandartItemCharacteristics.Cursed = true;
                oPtr.IdentCursed = true;
            }
            else
            {
                if (!oPtr.IdentCursed)
                {
                    changed = true;
                }
                oPtr.RandartItemCharacteristics.Cursed = true;
                oPtr.IdentCursed = true;
            }
            if (changed)
            {
                SaveGame.MsgPrint("There is a malignant black aura surrounding you...");
                if (!string.IsNullOrEmpty(oPtr.Inscription))
                {
                    if (oPtr.Inscription == "uncursed")
                    {
                        oPtr.Inscription = string.Empty;
                    }
                }
            }
        }

        public bool DecreaseAbilityScore(int stat, int amount, bool permanent)
        {
            int loss;
            bool res = false;
            int cur = AbilityScores[stat].Innate;
            int max = AbilityScores[stat].InnateMax;
            bool same = cur == max;
            if (cur > 3)
            {
                if (cur <= 18)
                {
                    if (amount > 90)
                    {
                        cur--;
                    }
                    if (amount > 50)
                    {
                        cur--;
                    }
                    if (amount > 20)
                    {
                        cur--;
                    }
                    cur--;
                }
                else
                {
                    loss = ((((cur - 18) / 2) + 1) / 2) + 1;
                    if (loss < 1)
                    {
                        loss = 1;
                    }
                    loss = (Program.Rng.DieRoll(loss) + loss) * amount / 100;
                    if (loss < amount / 2)
                    {
                        loss = amount / 2;
                    }
                    cur -= loss;
                    if (cur < 18)
                    {
                        cur = amount <= 20 ? 18 : 17;
                    }
                }
                if (cur < 3)
                {
                    cur = 3;
                }
                if (cur != AbilityScores[stat].Innate)
                {
                    res = true;
                }
            }
            if (permanent && max > 3)
            {
                if (max <= 18)
                {
                    if (amount > 90)
                    {
                        max--;
                    }
                    if (amount > 50)
                    {
                        max--;
                    }
                    if (amount > 20)
                    {
                        max--;
                    }
                    max--;
                }
                else
                {
                    loss = ((((max - 18) / 2) + 1) / 2) + 1;
                    loss = (Program.Rng.DieRoll(loss) + loss) * amount / 100;
                    if (loss < amount / 2)
                    {
                        loss = amount / 2;
                    }
                    max -= loss;
                    if (max < 18)
                    {
                        max = amount <= 20 ? 18 : 17;
                    }
                }
                if (same || max < cur)
                {
                    max = cur;
                }
                if (max != AbilityScores[stat].InnateMax)
                {
                    res = true;
                }
            }
            if (res)
            {
                AbilityScores[stat].Innate = cur;
                AbilityScores[stat].InnateMax = max;
                SaveGame.UpdateBonusesFlaggedAction.Set();
            }
            return res;
        }

        public string DescribeWieldLocation(int index)
        {
            BaseInventorySlot inventorySlot = SaveGame.SingletonRepository.InventorySlots.Single(_inventorySlot => _inventorySlot.InventorySlots.Contains(index));
            return inventorySlot.DescribeWieldLocation(index);
        }

        public void GainExperience(int amount)
        {
            ExperiencePoints += amount;
            if (ExperiencePoints < MaxExperienceGained)
            {
                MaxExperienceGained += amount / 5;
            }
            CheckExperience();
        }

        public void GainLevelReward()
        {
            GooPatron.GetReward(SaveGame);
        }

        public ItemCharacteristics GetAbilitiesAsItemFlags()
        {
            ItemCharacteristics itemCharacteristics = new ItemCharacteristics();
            if ((BaseCharacterClass.ID == CharacterClass.Warrior && Level > 29) || (BaseCharacterClass.ID == CharacterClass.Paladin && Level > 39) || (BaseCharacterClass.ID == CharacterClass.Fanatic && Level > 39))
            {
                itemCharacteristics.ResFear = true;
            }
            if (BaseCharacterClass.ID == CharacterClass.Fanatic && Level > 29)
            {
                itemCharacteristics.ResChaos = true;
            }
            if (BaseCharacterClass.ID == CharacterClass.Cultist && Level > 19)
            {
                itemCharacteristics.ResChaos = true;
            }
            if (BaseCharacterClass.ID == CharacterClass.Monk && Level > 9 && !SaveGame.MartialArtistHeavyArmour())
            {
                itemCharacteristics.Speed = true;
            }
            if (BaseCharacterClass.ID == CharacterClass.Monk && Level > 24 && !SaveGame.MartialArtistHeavyArmour())
            {
                itemCharacteristics.FreeAct = true;
            }
            if (BaseCharacterClass.ID == CharacterClass.Mindcrafter)
            {
                if (Level > 9)
                {
                    itemCharacteristics.ResFear = true;
                }
                if (Level > 19)
                {
                    itemCharacteristics.SustWis = true;
                }
                if (Level > 29)
                {
                    itemCharacteristics.ResConf = true;
                }
                if (Level > 39)
                {
                    itemCharacteristics.Telepathy = true;
                }
            }
            if (BaseCharacterClass.ID == CharacterClass.Mystic)
            {
                if (Level > 9)
                {
                    itemCharacteristics.ResConf = true;
                }
                if (Level > 9 && !SaveGame.MartialArtistHeavyArmour())
                {
                    itemCharacteristics.Speed = true;
                }
                if (Level > 24)
                {
                    itemCharacteristics.ResFear = true;
                }
                if (Level > 29 && !SaveGame.MartialArtistHeavyArmour())
                {
                    itemCharacteristics.FreeAct = true;
                }
                if (Level > 39)
                {
                    itemCharacteristics.Telepathy = true;
                }
            }
            if (BaseCharacterClass.ID == CharacterClass.ChosenOne)
            {
                itemCharacteristics.Lightsource = true;
                if (Level >= 2)
                {
                    itemCharacteristics.ResConf = true;
                }
                if (Level >= 4)
                {
                    itemCharacteristics.ResFear = true;
                }
                if (Level >= 6)
                {
                    itemCharacteristics.ResBlind = true;
                }
                if (Level >= 8)
                {
                    itemCharacteristics.Feather = true;
                }
                if (Level >= 10)
                {
                    itemCharacteristics.SeeInvis = true;
                }
                if (Level >= 12)
                {
                    itemCharacteristics.SlowDigest = true;
                }
                if (Level >= 14)
                {
                    itemCharacteristics.SustCon = true;
                }
                if (Level >= 16)
                {
                    itemCharacteristics.ResPois = true;
                }
                if (Level >= 18)
                {
                    itemCharacteristics.SustDex = true;
                }
                if (Level >= 20)
                {
                    itemCharacteristics.SustStr = true;
                }
                if (Level >= 22)
                {
                    itemCharacteristics.HoldLife = true;
                }
                if (Level >= 24)
                {
                    itemCharacteristics.FreeAct = true;
                }
                if (Level >= 26)
                {
                    itemCharacteristics.Telepathy = true;
                }
                if (Level >= 28)
                {
                    itemCharacteristics.ResDark = true;
                }
                if (Level >= 30)
                {
                    itemCharacteristics.ResLight = true;
                }
                if (Level >= 32)
                {
                    itemCharacteristics.SustCha = true;
                }
                if (Level >= 34)
                {
                    itemCharacteristics.ResSound = true;
                }
                if (Level >= 36)
                {
                    itemCharacteristics.ResDisen = true;
                }
                if (Level >= 38)
                {
                    itemCharacteristics.Regen = true;
                }
                if (Level >= 40)
                {
                    itemCharacteristics.SustInt = true;
                }
                if (Level >= 42)
                {
                    itemCharacteristics.ResChaos = true;
                }
                if (Level >= 44)
                {
                    itemCharacteristics.SustWis = true;
                }
                if (Level >= 46)
                {
                    itemCharacteristics.ResNexus = true;
                }
                if (Level >= 48)
                {
                    itemCharacteristics.ResShards = true;
                }
                if (Level >= 50)
                {
                    itemCharacteristics.ResNether = true;
                }
            }

            Race.UpdateRacialAbilities(Level, itemCharacteristics);
            if (Dna.Regen)
            {
                itemCharacteristics.Regen = true;
            }
            if (Dna.SuppressRegen)
            {
                itemCharacteristics.Regen = false;
            }
            if (Dna.SpeedBonus != 0)
            {
                itemCharacteristics.Speed = true;
            }
            if (Dna.ElecHit)
            {
                itemCharacteristics.ShElec = true;
            }
            if (Dna.FireHit)
            {
                itemCharacteristics.ShFire = true;
                itemCharacteristics.Lightsource = true;
            }
            if (Dna.FeatherFall)
            {
                itemCharacteristics.Feather = true;
            }
            if (Dna.ResFear)
            {
                itemCharacteristics.ResFear = true;
            }
            if (Dna.Esp)
            {
                itemCharacteristics.Telepathy = true;
            }
            if (Dna.FreeAction)
            {
                itemCharacteristics.FreeAct = true;
            }
            if (Dna.SustainAll)
            {
                itemCharacteristics.SustCon = true;
                if (Level > 9)
                {
                    itemCharacteristics.SustStr = true;
                }
                if (Level > 19)
                {
                    itemCharacteristics.SustDex = true;
                }
                if (Level > 29)
                {
                    itemCharacteristics.SustWis = true;
                }
                if (Level > 39)
                {
                    itemCharacteristics.SustInt = true;
                }
                if (Level > 49)
                {
                    itemCharacteristics.SustCha = true;
                }
            }
            return itemCharacteristics;
        }

        public int GetScore(SaveGame saveGame)
        {
            int score = (MaxLevelGained - 1) * 100;
            foreach (Dungeon dungeon in SaveGame.Dungeons)
            {
                if (dungeon.RecallLevel > 0)
                {
                    score += ((dungeon.RecallLevel + dungeon.Offset) * 10);
                }
            }
            for (int i = 0; i < SaveGame.Quests.Count; i++)
            {
                if (SaveGame.Quests[i].Level == 0)
                {
                    score += 100;
                }
            }
            if (IsWinner)
            {
                score += 1000;
            }
            if (MaxLevelGained < 50)
            {
                int prev = 0;
                if (MaxLevelGained > 1)
                {
                    prev = Constants.PlayerExp[MaxLevelGained - 2] * ExperienceMultiplier / 100;
                }
                int next = Constants.PlayerExp[MaxLevelGained - 1] * ExperienceMultiplier / 100;
                int numerator = MaxExperienceGained - prev;
                int denominator = next - prev;
                int fraction = 100 * numerator / denominator;
                score += fraction;
            }
            return score;
        }

        public void InputPlayerName()
        {
            SaveGame.Screen.Clear(42);
            SaveGame.Screen.PrintLine(Colour.Orange, "[Enter your player's name above, or hit ESCAPE]", 43, 2);
            const int col = 15;
            while (true)
            {
                SaveGame.Screen.Goto(2, col);
                if (SaveGame.AskforAux(out string newName, Name, 12))
                {
                    Name = newName;

                    // Check to see if the name has actually changed (excluding any leading or trailing spaces).
                    if (newName.Trim() != Name.Trim())
                    {
                        Generation = 1;
                    }
                }

                break;
            }
            Name = Name.PadRight(12);
            SaveGame.Screen.Print(Colour.Brown, Name, 2, col);
            //SaveGame.Screen.Clear(22);
        }

        public void LoseExperience(int amount)
        {
            if (amount > ExperiencePoints)
            {
                amount = ExperiencePoints;
            }
            ExperiencePoints -= amount;
            CheckExperience();
        }

        public void PolymorphSelf(SaveGame saveGame)
        {
            int effects = Program.Rng.DieRoll(2);
            int tmp = 0;
            bool moreEffects = true;
            SaveGame.MsgPrint("You feel a change coming over you...");
            while (effects-- != 0 && moreEffects)
            {
                switch (Program.Rng.DieRoll(12))
                {
                    case 1:
                    case 2:
                    case 3:
                        PolymorphWounds();
                        break;

                    case 4:
                    case 5:
                    case 6:
                        Dna.GainMutation();
                        break;

                    case 7:
                        {
                            int newRaceIndex;
                            Race newRace;
                            do
                            {
                                newRaceIndex = Program.Rng.RandomLessThan(SaveGame.SingletonRepository.Races.Count);
                                newRace = SaveGame.SingletonRepository.Races[newRaceIndex];
                            } while (newRace is Race);
                            SaveGame.MsgPrint($"You turn into {newRace.IndefiniteArticleForTitle} {newRace.Title}!");
                            ChangeRace(newRace);
                        }
                        SaveGame.Level.RedrawSingleLocation(MapY, MapX);
                        moreEffects = false;
                        break;

                    case 8:
                        SaveGame.MsgPrint("You polymorph into an abomination!");
                        while (tmp < 6)
                        {
                            DecreaseAbilityScore(tmp, Program.Rng.FixedSeed + 6, Program.Rng.DieRoll(3) == 1);
                            tmp++;
                        }
                        if (Program.Rng.DieRoll(6) == 1)
                        {
                            SaveGame.MsgPrint("You find living difficult in your present form!");
                            TakeHit(Program.Rng.DiceRoll(Program.Rng.DieRoll(Level), Level), "a lethal mutation");
                        }
                        ShuffleAbilityScores();
                        break;

                    default:
                        ShuffleAbilityScores();
                        break;
                }
            }
        }

        public void PolymorphWounds()
        {
            int wounds = TimedBleeding.TurnsRemaining;
            int hitP = MaxHealth - Health;
            int change = Program.Rng.DiceRoll(Level, 5);
            bool nastyEffect = Program.Rng.DieRoll(5) == 1;
            if (!(wounds != 0 || hitP != 0 || nastyEffect))
            {
                return;
            }
            if (nastyEffect)
            {
                SaveGame.MsgPrint("A new wound was created!");
                TakeHit(change, "a polymorphed wound");
                TimedBleeding.SetTimer(change);
            }
            else
            {
                SaveGame.MsgPrint("Your wounds are polymorphed into less serious ones.");
                RestoreHealth(change);
                TimedBleeding.SetTimer(TimedBleeding.TurnsRemaining - (change / 2));
            }
        }

        public void PrintSpells(int[] spells, int y, int x, BaseRealm? realm)
        {
            int i;
            int set = realm == PrimaryRealm ? 0 : 1;
            SaveGame.Screen.PrintLine("", y, x);
            SaveGame.Screen.Print("Name", y, x + 5);
            SaveGame.Screen.Print("Lv Mana Fail Info", y, x + 35);
            for (i = 0; i < spells.Length; i++)
            {
                int spell = spells[i];
                Spell sPtr = SaveGame.Spells[set][spell];
                SaveGame.Screen.PrintLine($"{i.IndexToLetter()}) {sPtr.SummaryLine()}", y + i + 1, x);
            }
            SaveGame.Screen.PrintLine("", y + i + 1, x);
        }

        public void RegenerateHealth(int percent)
        {
            int oldHealth = Health;
            int newHealth = (MaxHealth * percent) + Constants.PyRegenHpbase;
            Health += newHealth >> 16;
            if (Health < 0 && oldHealth > 0)
            {
                Health = Constants.MaxShort;
            }
            int newFractionalHealth = (newHealth & 0xFFFF) + FractionalHealth;
            if (newFractionalHealth >= 0x10000)
            {
                FractionalHealth = newFractionalHealth - 0x10000;
                Health++;
            }
            else
            {
                FractionalHealth = newFractionalHealth;
            }
            if (Health >= MaxHealth)
            {
                Health = MaxHealth;
                FractionalHealth = 0;
            }
            if (oldHealth != Health)
            {
                SaveGame.RedrawHpFlaggedAction.Set();
            }
        }

        public void RegenerateMana(int percent)
        {
            int oldMana = Mana;
            int newMana = (MaxMana * percent) + Constants.PyRegenMnbase;
            Mana += newMana >> 16;
            if (Mana < 0 && oldMana > 0)
            {
                Mana = Constants.MaxShort;
            }
            int newFractionalMana = (newMana & 0xFFFF) + FractionalMana;
            if (newFractionalMana >= 0x10000L)
            {
                FractionalMana = newFractionalMana - 0x10000;
                Mana++;
            }
            else
            {
                FractionalMana = newFractionalMana;
            }
            if (Mana >= MaxMana)
            {
                Mana = MaxMana;
                FractionalMana = 0;
            }
            if (oldMana != Mana)
            {
                SaveGame.RedrawManaFlaggedAction.Set();
            }
        }

        public void RerollHitPoints()
        {
            int i;
            PlayerHp[0] = HitDie;
            int lastroll = HitDie;
            for (i = 1; i < Constants.PyMaxLevel; i++)
            {
                PlayerHp[i] = lastroll;
                lastroll--;
                if (lastroll < 1)
                {
                    lastroll = HitDie;
                }
            }
            for (i = 1; i < Constants.PyMaxLevel; i++)
            {
                int j = Program.Rng.DieRoll(Constants.PyMaxLevel - 1);
                lastroll = PlayerHp[i];
                PlayerHp[i] = PlayerHp[j];
                PlayerHp[j] = lastroll;
            }
            for (i = 1; i < Constants.PyMaxLevel; i++)
            {
                PlayerHp[i] = PlayerHp[i - 1] + PlayerHp[i];
            }
            SaveGame.UpdateHealthFlaggedAction.Set();
            SaveGame.RedrawHpFlaggedAction.Set();
            SaveGame.HandleStuff();
        }

        public bool RestoreAbilityScore(int stat)
        {
            if (AbilityScores[stat].Innate != AbilityScores[stat].InnateMax)
            {
                AbilityScores[stat].Innate = AbilityScores[stat].InnateMax;
                SaveGame.UpdateBonusesFlaggedAction.Set();
                return true;
            }
            return false;
        }

        public bool RestoreHealth(int num)
        {
            if (Health < MaxHealth)
            {
                Health += num;
                if (Health >= MaxHealth)
                {
                    Health = MaxHealth;
                    FractionalHealth = 0;
                }
                SaveGame.RedrawHpFlaggedAction.Set();
                if (num < 5)
                {
                    SaveGame.MsgPrint("You feel a little better.");
                }
                else if (num < 15)
                {
                    SaveGame.MsgPrint("You feel better.");
                }
                else if (num < 35)
                {
                    SaveGame.MsgPrint("You feel much better.");
                }
                else
                {
                    SaveGame.MsgPrint("You feel very good.");
                }
                return true;
            }
            return false;
        }

        public bool RestoreLevel()
        {
            if (ExperiencePoints < MaxExperienceGained)
            {
                SaveGame.MsgPrint("You feel your life energies returning.");
                ExperiencePoints = MaxExperienceGained;
                CheckExperience();
                return true;
            }
            return false;
        }

        public void SenseInventory()
        {
            int playerLevel = Level;
            if (TimedConfusion.TurnsRemaining != 0)
            {
                return;
            }
            if (!BaseCharacterClass.SenseInventoryTest(Level))
            {
                return;
            }
            bool detailed = BaseCharacterClass.DetailedSenseInventory;

            // Enumerate each of the inventory slots.
            foreach (BaseInventorySlot inventorySlot in SaveGame.SingletonRepository.InventorySlots)
            {
                // Enumerate each of the items in the inventory slot.
                foreach (int i in inventorySlot)
                {
                    Item? item = SaveGame.GetInventoryItem(i);
                    if (item == null)
                    {
                        continue;
                    }
                    bool okay = item.IdentityCanBeSensed;
                    if (!okay)
                    {
                        continue;
                    }
                    if (item.IdentSense)
                    {
                        continue;
                    }
                    if (item.IsKnown())
                    {
                        continue;
                    }
                    if (!inventorySlot.IdentitySenseChanceTest)
                    {
                        continue;
                    }
                    string feel = detailed ? item.GetDetailedFeeling() : item.GetVagueFeeling();
                    if (string.IsNullOrEmpty(feel))
                    {
                        continue;
                    }
                    string oName = item.Description(false, 0);
                    string isare = item.Count == 1 ? "is" : "are";
                    SaveGame.MsgPrint($"You feel the {oName} ({i.IndexToLabel()}) {inventorySlot.SenseLocation(i)} {isare} {feel}...");
                    item.IdentSense = true;
                    if (string.IsNullOrEmpty(item.Inscription))
                    {
                        item.Inscription = feel;
                    }
                    SaveGame.NoticeCombineAndReorderFlaggedAction.Set();
                }
            }
        }

        public bool SetFood(int v)
        {
            int oldAux, newAux;
            bool notice = false;
            v = v > 20000 ? 20000 : v < 0 ? 0 : v;
            if (Food < Constants.PyFoodFaint)
            {
                oldAux = 0;
            }
            else if (Food < Constants.PyFoodWeak)
            {
                oldAux = 1;
            }
            else if (Food < Constants.PyFoodAlert)
            {
                oldAux = 2;
            }
            else if (Food < Constants.PyFoodFull)
            {
                oldAux = 3;
            }
            else if (Food < Constants.PyFoodMax)
            {
                oldAux = 4;
            }
            else
            {
                oldAux = 5;
            }
            if (v < Constants.PyFoodFaint)
            {
                newAux = 0;
            }
            else if (v < Constants.PyFoodWeak)
            {
                newAux = 1;
            }
            else if (v < Constants.PyFoodAlert)
            {
                newAux = 2;
            }
            else if (v < Constants.PyFoodFull)
            {
                newAux = 3;
            }
            else if (v < Constants.PyFoodMax)
            {
                newAux = 4;
            }
            else
            {
                newAux = 5;
            }
            if (newAux > oldAux)
            {
                switch (newAux)
                {
                    case 1:
                        SaveGame.MsgPrint("You are still weak.");
                        break;

                    case 2:
                        SaveGame.MsgPrint("You are still hungry.");
                        break;

                    case 3:
                        SaveGame.MsgPrint("You are no longer hungry.");
                        break;

                    case 4:
                        SaveGame.MsgPrint("You are full!");
                        break;

                    case 5:
                        SaveGame.MsgPrint("You have gorged yourself!");
                        break;
                }
                notice = true;
            }
            else if (newAux < oldAux)
            {
                switch (newAux)
                {
                    case 0:
                        SaveGame.MsgPrint("You are getting faint from hunger!");
                        break;

                    case 1:
                        SaveGame.MsgPrint("You are getting weak from hunger!");
                        break;

                    case 2:
                        SaveGame.MsgPrint("You are getting hungry.");
                        break;

                    case 3:
                        SaveGame.MsgPrint("You are no longer full.");
                        break;

                    case 4:
                        SaveGame.MsgPrint("You are no longer gorged.");
                        break;
                }
                notice = true;
            }
            Food = v;
            if (!notice)
            {
                return false;
            }
            SaveGame.Disturb(false);
            SaveGame.UpdateBonusesFlaggedAction.Set();
            SaveGame.RedrawHungerFlaggedAction.Set();
            SaveGame.HandleStuff();
            return true;
        }

        public void ShuffleAbilityScores()
        {
            int jj;
            int ii = Program.Rng.RandomLessThan(6);
            for (jj = ii; jj != ii; jj = Program.Rng.RandomLessThan(6))
            {
            }
            int max1 = AbilityScores[ii].InnateMax;
            int cur1 = AbilityScores[ii].Innate;
            int max2 = AbilityScores[jj].InnateMax;
            int cur2 = AbilityScores[jj].Innate;
            AbilityScores[ii].InnateMax = max2;
            AbilityScores[ii].Innate = cur2;
            AbilityScores[jj].InnateMax = max1;
            AbilityScores[jj].Innate = cur1;
            SaveGame.UpdateBonusesFlaggedAction.Set();
        }

        public bool SpellOkay(int spell, bool known, bool realm2)
        {
            int set = realm2 ? 1 : 0;
            Spell sPtr = SaveGame.Spells[set][spell % 32];
            if (sPtr.Level > Level)
            {
                return false;
            }
            if (sPtr.Forgotten)
            {
                return false;
            }
            if (sPtr.Learned)
            {
                return known;
            }
            return !known;
        }

        public void TakeHit(int damage, string hitFrom)
        {
            bool penInvuln = false;
            int warning = MaxHealth * Constants.HitpointWarn / 10;
            if (IsDead)
            {
                return;
            }
            SaveGame.Disturb(true);
            if (TimedInvulnerability.TurnsRemaining != 0 && damage < 9000)
            {
                if (Program.Rng.DieRoll(Constants.PenetrateInvulnerability) == 1)
                {
                    penInvuln = true;
                }
                else
                {
                    return;
                }
            }
            if (TimedEtherealness.TurnsRemaining != 0)
            {
                damage /= 10;
                if (damage == 0 && Program.Rng.DieRoll(10) == 1)
                {
                    damage = 1;
                }
            }
            Health -= damage;
            SaveGame.RedrawHpFlaggedAction.Set();
            if (penInvuln)
            {
                SaveGame.MsgPrint("The attack penetrates your shield of invulnerability!");
            }
            if (Health < 0)
            {
                if (Program.Rng.DieRoll(10) <= Religion.GetNamedDeity(GodName.Zo_Kalar).AdjustedFavour)
                {
                    SaveGame.MsgPrint("Zo-Kalar's favour saves you from death!");
                    Health += damage;
                }
                else
                {
                    if (IsWizard && !SaveGame.GetCheck("Die? "))
                    {
                        Health += damage;
                    }
                    else
                    {
                        SaveGame.PlaySound(SoundEffect.PlayerDeath);
                        SaveGame.MsgPrint("You die.");
                        SaveGame.MsgPrint(null);
                        SaveGame.DiedFrom = hitFrom;
                        if (TimedHallucinations.TurnsRemaining != 0)
                        {
                            SaveGame.DiedFrom += "(?)";
                        }
                        IsWinner = false;
                        IsDead = true;
                        return;
                    }
                }
            }
            if (Health < warning)
            {
                SaveGame.PlaySound(SoundEffect.HealthWarning);
                SaveGame.MsgPrint("*** LOW HITPOINT WARNING! ***");
                SaveGame.MsgPrint(null);
            }
        }

        public void ToggleRecall()
        {
            if (WordOfRecallDelay == 0)
            {
                WordOfRecallDelay = Program.Rng.DieRoll(20) + 15;
                SaveGame.MsgPrint("The air about you becomes charged...");
            }
            else
            {
                WordOfRecallDelay = 0;
                SaveGame.MsgPrint("A tension leaves the air around you...");
            }
        }

        public bool TryDecreasingAbilityScore(int stat)
        {
            bool sust = false;
            switch (stat)
            {
                case Ability.Strength:
                    if (HasSustainStrength)
                    {
                        sust = true;
                    }
                    break;

                case Ability.Intelligence:
                    if (HasSustainIntelligence)
                    {
                        sust = true;
                    }
                    break;

                case Ability.Wisdom:
                    if (HasSustainWisdom)
                    {
                        sust = true;
                    }
                    break;

                case Ability.Dexterity:
                    if (HasSustainDexterity)
                    {
                        sust = true;
                    }
                    break;

                case Ability.Constitution:
                    if (HasSustainConstitution)
                    {
                        sust = true;
                    }
                    break;

                case Ability.Charisma:
                    if (HasSustainCharisma)
                    {
                        sust = true;
                    }
                    break;
            }
            if (sust)
            {
                SaveGame.MsgPrint(
                    $"You feel {Constants.DescStatNeg[stat]} for a moment, but the feeling passes.");
                return true;
            }
            if (Program.Rng.DieRoll(10) <= Religion.GetNamedDeity(GodName.Lobon).AdjustedFavour)
            {
                SaveGame.MsgPrint($"You feel {Constants.DescStatNeg[stat]} for a moment, but Lobon's favour protects you.");
                return true;
            }
            if (DecreaseAbilityScore(stat, 10, false))
            {
                SaveGame.MsgPrint($"You feel very {Constants.DescStatNeg[stat]}.");
                return true;
            }
            return false;
        }

        public bool TryIncreasingAbilityScore(int stat)
        {
            bool res = RestoreAbilityScore(stat);
            if (IncreaseAbilityScore(stat))
            {
                SaveGame.MsgPrint($"Wow!  You feel very {Constants.DescStatPos[stat]}!");
                return true;
            }
            if (res)
            {
                SaveGame.MsgPrint($"You feel less {Constants.DescStatNeg[stat]}.");
                return true;
            }
            return false;
        }

        public bool TryRestoringAbilityScore(int stat)
        {
            if (RestoreAbilityScore(stat))
            {
                SaveGame.MsgPrint($"You feel less {Constants.DescStatNeg[stat]}.");
                return true;
            }
            return false;
        }

        private bool IncreaseAbilityScore(int which)
        {
            int value = AbilityScores[which].Innate;
            if (value < 18 + 100)
            {
                int gain;
                if (value < 18)
                {
                    gain = Program.Rng.RandomLessThan(100) < 75 ? 1 : 2;
                    value += gain;
                }
                else if (value < 18 + 98)
                {
                    gain = (((18 + 100 - value) / 2) + 3) / 2;
                    if (gain < 1)
                    {
                        gain = 1;
                    }
                    value += Program.Rng.DieRoll(gain) + (gain / 2);
                    if (value > 18 + 99)
                    {
                        value = 18 + 99;
                    }
                }
                else
                {
                    value++;
                }
                AbilityScores[which].Innate = value;
                if (value > AbilityScores[which].InnateMax)
                {
                    AbilityScores[which].InnateMax = value;
                }
                SaveGame.UpdateBonusesFlaggedAction.Set();
                return true;
            }
            return false;
        }

        public bool GetItemOkay(Item? item, IItemFilter? itemFilter)
        {
            if (item == null)
            {
                return false;
            }
            return ItemMatchesFilter(item, itemFilter);
        }

        public int InvenCarry(Item oPtr)
        {
            int j;
            int n = -1;
            for (j = 0; j < InventorySlot.PackCount; j++)
            {
                Item? jPtr = SaveGame.GetInventoryItem(j);
                if (jPtr == null)
                {
                    continue;
                }
                n = j;
                if (oPtr.CanAbsorb(jPtr))
                {
                    jPtr.Absorb(oPtr);
                    SaveGame.Player.WeightCarried += oPtr.Count * oPtr.Weight;
                    SaveGame.UpdateBonusesFlaggedAction.Set();
                    return j;
                }
            }
            if (SaveGame._invenCnt > InventorySlot.PackCount)
            {
                return -1;
            }
            for (j = 0; j <= InventorySlot.PackCount; j++)
            {
                Item? jPtr = SaveGame.GetInventoryItem(j);
                if (jPtr == null)
                {
                    break;
                }
            }
            int i = j;
            if (i < InventorySlot.PackCount)
            {
                for (j = 0; j < InventorySlot.PackCount; j++)
                {
                    Item? jPtr = SaveGame.GetInventoryItem(j);
                    if (jPtr == null)
                    {
                        break;
                    }
                    int compare = oPtr.CompareTo(jPtr);
                    if (compare == -1)
                    {
                        break;
                    }
                }
                i = j;
                for (int k = n; k >= i; k--)
                {
                    SaveGame.SetInventoryItem(k + 1, SaveGame.GetInventoryItem(k));
                }
                SaveGame.SetInventoryItem(i, null);
            }

            SaveGame.SetInventoryItem(i, oPtr.Clone());
            oPtr = SaveGame.GetInventoryItem(i);
            oPtr.Y = 0;
            oPtr.X = 0;
            oPtr.HoldingMonsterIndex = 0;
            SaveGame.Player.WeightCarried += oPtr.Count * oPtr.Weight;
            SaveGame._invenCnt++;
            SaveGame.UpdateBonusesFlaggedAction.Set();
            SaveGame.NoticeCombineAndReorderFlaggedAction.Set();
            return i;
        }

        public bool InvenCarryOkay(Item oPtr)
        {
            if (SaveGame._invenCnt < InventorySlot.PackCount)
            {
                return true;
            }
            for (int j = 0; j < InventorySlot.PackCount; j++)
            {
                Item? jPtr = SaveGame.GetInventoryItem(j);
                if (jPtr == null)
                {
                    continue;
                }
                if (jPtr.CanAbsorb(oPtr))
                {
                    return true;
                }
            }
            return false;
        }

        public int InvenDamage(Func<Item, bool> testerFunc, int perc)
        {
            int k = 0;
            for (int i = 0; i < InventorySlot.PackCount; i++)
            {
                Item oPtr = SaveGame.GetInventoryItem(i);
                if (oPtr != null && oPtr.FixedArtifact == null && string.IsNullOrEmpty(oPtr.RandartName) && testerFunc(oPtr))
                {
                    int j;
                    int amt;
                    for (amt = j = 0; j < oPtr.Count; ++j)
                    {
                        if (Program.Rng.RandomLessThan(100) < perc)
                        {
                            amt++;
                        }
                    }
                    if (amt != 0)
                    {
                        string oName = oPtr.Description(false, 3);
                        string y = oPtr.Count > 1 ? (amt == oPtr.Count ? "All of y" : (amt > 1 ? "Some of y" : "One of y")) : "Y";
                        string w = amt > 1 ? "were" : "was";
                        SaveGame.MsgPrint($"{y}our {oName} ({i.IndexToLabel()}) {w} destroyed!");
                        if (oPtr.Factory.CategoryEnum == ItemTypeEnum.Potion)
                        {
                            PotionItemFactory potion = (PotionItemFactory)oPtr.Factory;
                            potion.Smash(SaveGame, 0, SaveGame.Player.MapY, SaveGame.Player.MapX);
                        }
                        InvenItemIncrease(i, -amt);
                        InvenItemOptimize(i);
                        k += amt;
                    }
                }
            }
            return k;
        }
        public void InvenDrop(Item oPtr, int amt)
        {
            if (amt <= 0)
            {
                return;
            }
            if (amt > oPtr.Count)
            {
                amt = oPtr.Count;
            }
            if (oPtr.IsInEquipment)
            {
                // Take the item off first.
                int? newItem = InvenTakeoff(oPtr, amt);
                if (newItem == null)
                {
                    return;
                }

                oPtr = SaveGame.GetInventoryItem(newItem.Value);

                // We took off the item, check to ensure that the item is not missing.
                if (oPtr == null)
                {
                    return;
                }
            }
            Item qPtr = oPtr.Clone(amt);
            string oName = qPtr.Description(true, 3);
            SaveGame.MsgPrint($"You drop {oName} ({oPtr.Label}).");
            SaveGame.Level.DropNear(qPtr, 0, SaveGame.Player.MapY, SaveGame.Player.MapX);
            oPtr.ItemIncrease(-amt);
            oPtr.ItemDescribe();
            oPtr.ItemOptimize();
        }

        [Obsolete("Use InvenDrop(Item, int)")]
        public void InvenDrop(int item, int amt)
        {
            Item? oPtr = SaveGame.GetInventoryItem(item);
            if (oPtr == null)
            {
                return;
            }
            InvenDrop(oPtr, amt);
        }

        public void InvenItemDescribe(int item)
        {
            Item? oPtr = SaveGame.GetInventoryItem(item);
            if (oPtr == null)
            {
                return;
            }
            string oName = oPtr.Description(true, 3);
            SaveGame.MsgPrint($"You have {oName}.");
        }

        public void InvenItemIncrease(int item, int num)
        {
            Item? oPtr = SaveGame.GetInventoryItem(item);
            if (oPtr == null)
            {
                return;
            }
            num += oPtr.Count;
            if (num > 255)
            {
                num = 255;
            }
            else if (num < 0)
            {
                num = 0;
            }
            num -= oPtr.Count;
            if (num != 0)
            {
                oPtr.Count += num;
                SaveGame.Player.WeightCarried += num * oPtr.Weight;
                SaveGame.UpdateBonusesFlaggedAction.Set();
                SaveGame.UpdateManaFlaggedAction.Set();
                SaveGame.NoticeCombineAndReorderFlaggedAction.Set();
            }
        }

        public void InvenItemOptimize(int item)
        {
            Item? oPtr = SaveGame.GetInventoryItem(item);
            if (oPtr == null)
            {
                return;
            }
            if (oPtr.Count > 0)
            {
                return;
            }
            if (item < InventorySlot.MeleeWeapon)
            {
                int i;
                SaveGame._invenCnt--;
                for (i = item; i < InventorySlot.PackCount; i++)
                {
                    SaveGame.SetInventoryItem(i, SaveGame.GetInventoryItem(i + 1));
                }
                SaveGame.SetInventoryItem(i, null);
            }
            else
            {
                SaveGame.SetInventoryItem(item, null);
                SaveGame.UpdateBonusesFlaggedAction.Set();
                SaveGame.UpdateTorchRadiusFlaggedAction.Set();
                SaveGame.UpdateManaFlaggedAction.Set();
            }
        }

        public int? InvenTakeoff(Item oPtr, int amt)
        {
            string act;
            if (amt <= 0)
            {
                return null;
            }
            if (amt > oPtr.Count)
            {
                amt = oPtr.Count;
            }
            Item qPtr = oPtr.Clone(amt);
            string oName = qPtr.Description(true, 3);
            act = oPtr.TakeOffMessage;
            oPtr.ItemIncrease(-amt);
            oPtr.ItemOptimize();
            int slot = InvenCarry(qPtr);
            SaveGame.MsgPrint($"{act} {oName} ({slot.IndexToLabel()}).");
            return slot;
        }

        [Obsolete("Use InvenTakeOff(Item, int)")]
        public int? InvenTakeoff(int item, int amt)
        {
            Item? oPtr = SaveGame.GetInventoryItem(item);
            if (oPtr == null)
            {
                return null;
            }
            return InvenTakeoff(oPtr, amt);
        }

        public bool ItemMatchesFilter(Item item, IItemFilter? itemFilter)
        {
            if (item.Factory == null)
            {
                return false;
            }
            if (item.Category == ItemTypeEnum.Gold)
            {
                return false;
            }
            if (itemFilter != null)
            {
                if (!itemFilter.ItemMatches(item))
                {
                    return false;
                }
            }
            return true;
        }

        public int LabelToEquip(char c)
        {
            int i = (char.IsLower(c) ? c.LetterToNumber() : -1) + InventorySlot.MeleeWeapon;
            if (i < InventorySlot.MeleeWeapon || i >= InventorySlot.Total)
            {
                return -1; // TODO: Return null
            }
            if (SaveGame.GetInventoryItem(i) == null)
            {
                return -1; // TODO: Return null
            }
            return i;
        }

        public int LabelToInven(char c) 
        {
            int i = char.IsLower(c) ? c.LetterToNumber() : -1;
            if (i < 0 || i > InventorySlot.PackCount)
            {
                return -1; // TODO: Return null
            }
            if (SaveGame.GetInventoryItem(i) == null)
            {
                return -1; // TODO: Return null
            }
            return i;
        }

        public void ShowEquip(IItemFilter? itemFilter)
        {
            ShowInventoryOptions options = new ShowInventoryOptions()
            {
                ShowEmptySlotsAsNothing = true,
                ShowFlavourColumn = true,
                ShowUsageColumn = true
            };
            ShowInven(_inventorySlot => _inventorySlot.IsEquipment, itemFilter, options);
        }

        /// <summary>
        /// Shows the players inventory on the screen.  Returns false, if the player has nothing in their inventory.
        /// </summary>
        /// <param name="inventorySlotPredicate"></param>
        /// <param name="itemFilter"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public bool ShowInven(Func<BaseInventorySlot, bool> inventorySlotPredicate, IItemFilter? itemFilter, ShowInventoryOptions? options = null)
        {
            if (options == null)
            {
                options = new ShowInventoryOptions();
            }

            BaseInventorySlot[] inventorySlots = SaveGame.SingletonRepository.InventorySlots
                .Where(_inventorySlot => inventorySlotPredicate(_inventorySlot))
                .OrderBy(_inventorySlot => _inventorySlot.SortOrder)
                .ToArray();

            const string labels = "abcdefghijklmnopqrstuvwxyz";
            ConsoleTable consoleTable = new ConsoleTable("label", "flavour", "usage", "description", "weight");
            consoleTable.Column("flavour").IsVisible = options.ShowFlavourColumn;
            consoleTable.Column("usage").IsVisible = options.ShowFlavourColumn;
            consoleTable.Column("weight").Alignment = new ConsoleTopRightAlignment();
            foreach (BaseInventorySlot inventorySlot in inventorySlots)
            {
                bool slotIsEmpty = true;
                foreach (int index in inventorySlot.InventorySlots)
                {
                    Item? oPtr = SaveGame.GetInventoryItem(index);
                    if (oPtr != null && (itemFilter == null || itemFilter.ItemMatches(oPtr)))
                    {
                        ConsoleTableRow consoleRow = consoleTable.AddRow();
                        consoleRow["label"] = new ConsoleString(Colour.White, $"{index.IndexToLabel()})");

                        if (oPtr.Factory != null)
                        {
                            // Apply flavour visuals
                            consoleRow["flavour"] = new ConsoleChar(oPtr.Factory.FlavorColour, oPtr.Factory.FlavorCharacter);
                        }
                        else
                        {
                            // There is no item.
                            consoleRow["flavour"] = new ConsoleChar(Colour.Background, ' ');
                        }
                        consoleRow["usage"] = new ConsoleString(Colour.White, $"{inventorySlot.MentionUse(index)}:");

                        Colour colour = oPtr.Factory == null ? Colour.White : oPtr.Factory.Colour;
                        consoleRow["description"] = new ConsoleString(colour, oPtr.Description(true, 3));

                        int wgt = oPtr.Weight * oPtr.Count;
                        consoleRow["weight"] = new ConsoleString(Colour.White, $"{wgt / 10}.{wgt % 10} lb");
                        slotIsEmpty = false;
                    }
                }
                if (options.ShowEmptySlotsAsNothing && slotIsEmpty)
                {
                    ConsoleTableRow consoleRow = consoleTable.AddRow();
                    consoleRow["label"] = new ConsoleString(Colour.White, $"{labels[consoleTable.Rows.Count() - 1]})");
                    consoleRow["usage"] = new ConsoleString(Colour.White, $"{inventorySlot.MentionUse(null)}:");
                    consoleRow["description"] = new ConsoleString(Colour.White, "(nothing)");
                    consoleRow["weight"] = new ConsoleString(Colour.White, $"0.0 lb");
                }
            }

            if (consoleTable.Rows.Count() > 0)
            {
                if (consoleTable.Width < 29)
                {
                    ConsoleWindow container = new ConsoleWindow(50, 1, 79, consoleTable.Height);
                    container.Clear(SaveGame, Colour.Background);
                    consoleTable.Render(SaveGame, container, new ConsoleTopLeftAlignment());
                }
                else
                {
                    consoleTable.Render(SaveGame, new ConsoleWindow(0, 1, 79, 26), new ConsoleTopRightAlignment());
                }
                return true;
            }
            return false;
        }
    }
}