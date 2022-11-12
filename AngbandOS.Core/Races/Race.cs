using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.Syllables;
using System.Diagnostics;
using AngbandOS.ItemCategories;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal abstract class Race
    {
        public abstract int[] AbilityBonus { get; }
        public abstract int AgeRange { get; }
        public abstract int BaseAge { get; }
        public abstract int BaseDeviceBonus { get; }
        public abstract int BaseDisarmBonus { get; }
        public abstract int BaseMeleeAttackBonus { get; }
        public abstract int BaseRangedAttackBonus { get; }
        public abstract int BaseSaveBonus { get; }
        public abstract int BaseSearchBonus { get; }
        public abstract int BaseSearchFrequency { get; }
        public abstract int BaseStealthBonus { get; }
        public abstract uint Choice { get; }
        public abstract int ExperienceFactor { get; }
        public abstract int FemaleBaseHeight { get; }
        public abstract int FemaleBaseWeight { get; }
        public abstract int FemaleHeightRange { get; }
        public abstract int FemaleWeightRange { get; }
        public abstract int HitDieBonus { get; }
        public abstract int Infravision { get; }
        public abstract int MaleBaseHeight { get; }
        public abstract int MaleBaseWeight { get; }
        public abstract int MaleHeightRange { get; }
        public abstract int MaleWeightRange { get; }
        public abstract string Title { get; }
        public virtual string IndefiniteArticleForTitle 
        { 
            get 
            {
                return "aeiouAEIOU".Contains(Title[0]) ? "an" : "a";
            } 
        }

        /// <summary>
        /// Returns the RaceId enumeration index for this race.  Deprecated.  Should be removed once all refactored.
        /// </summary>
        public abstract int Index { get; }

        /// <summary>
        /// Returns the description for the race.  The description is multi-line and has word-breaking macros \n built-in.  The description supports up to 6 lines.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Returns the PlayerHistory (SaveGame._backgroundTable) group used to produce the backstory fragments that are joined together on character generation.  Returns
        /// default argument values for races that do not have mutant powers.
        /// </summary>
        public abstract int Chart { get; }

        /// <summary>
        /// Returns a description of the racial powers, if the race has racial powers (HasRacialPowers == true).  Returns (none), by default.
        /// </summary>
        /// <param name="lvl"></param>
        /// <returns></returns>
        public virtual string RacialPowersDescription(int lvl) => "(none)";

        /// <summary>
        /// Returns true, if the race has mutant powers.  Returns false, by default.
        /// </summary>
        public virtual bool HasRacialPowers => false;

        /// <summary>
        /// Applies additional characteristics to a player based on the player level.  No characteristics are applied, by default.  Only humans, have no modifications.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="itemCharacteristics"></param>
        public virtual void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
        {
        }

        protected string CreateRandomNameFromSyllables(RaceNamingSyllables syllables)
        {
            string name = "";
            do
            {
                name = syllables.BeginningSyllables[Program.Rng.RandomLessThan(syllables.BeginningSyllables.Length)];
                name += syllables.MiddleSyllables[Program.Rng.RandomLessThan(syllables.MiddleSyllables.Length)];
                name += syllables.EndingSyllables[Program.Rng.RandomLessThan(syllables.EndingSyllables.Length)];
            } while (name.Length > 12);

            return name;
        }

        /// <summary>
        /// Create a random name for a character based on their race.
        /// </summary>
        public abstract string CreateRandomName();

        /// <summary>
        /// Returns one or two lines of self knowledge or null, if the race has no additional self knowledge.  Return null, by default.
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public virtual string[]? SelfKnowledge(int level) => null;

        public virtual void CalcBonuses(SaveGame saveGame)
        {
        }

        /// <summary>
        /// Returns true, if the race rests until dusk instead of dawn.  Vampires, zombies, spectres and skeletons return true.  Returns false, by default.
        /// </summary>
        public virtual bool RestsTillDuskInsteadOfDawn => false;

        /// <summary>
        /// Returns true, if the race is burned by sunlight.  Only vampires return true.  Returns false, by default.
        /// </summary>
        public virtual bool IsBurnedBySunlight => false;

        /// <summary>
        /// Returns true, if the race is damaged by darkness.  Returns true, by default.  Only vampires return false.
        /// </summary>
        public virtual bool IsDamagedByDarkness => true;

        /// <summary>
        /// Allow the race to consume food.  The full value of the food item is gained, by default.
        /// </summary>
        /// <param name="saveGame"></param>
        /// <param name="item"></param>
        public virtual void Eat(SaveGame saveGame, Item item)
        {
            // Everyone else gets the full value
            saveGame.Player.SetFood(saveGame.Player.Food + item.TypeSpecificValue);
        }

        /// <summary>
        /// Allow the race to quaff a potion.  Does nothing by default.  Skeletons are messy drinkers.
        /// </summary>
        /// <param name="saveGame"></param>
        /// <param name="item"></param>
        public virtual void Quaff(SaveGame saveGame, PotionItemCategory potion)
        {
        }

        /// <summary>
        /// Returns true, if the race can bleed.  Golems, skeletons and spectres cannot bleed.  Level 12 or greater zombies also do not bleed.  Returns true, by default.
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public virtual bool CanBleed(int level) => true;

        /// <summary>
        /// Returns true, if the race is susceptible to nether where resistance to nether is mostly negated.  Returns false, by default.  Only spectres return true.
        /// </summary>
        public virtual bool NegatesNetherResistance => false;

        /// <summary>
        /// Returns true, if the race gets a health boost, when projecting nether.  Returns false, by default.  Only spectres return true.
        /// </summary>
        public virtual bool ProjectingNetherRestoresHealth => false;

        /// <summary>
        /// Returns true, if the race is erthereal (can pass through walls).  Only spectres return true.  Returns false, by default.
        /// </summary>
        public virtual bool IsEthereal => false;

        public virtual void UseRacialPower(SaveGame saveGame)
        {
            // Other races don't have powers
            saveGame.MsgPrint("This race has no bonus power.");
            saveGame.EnergyUse = 0;
        }
    }
}
