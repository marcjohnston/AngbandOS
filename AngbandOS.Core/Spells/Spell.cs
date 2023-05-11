// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.CharacterClasses;

namespace AngbandOS.Core.Spells
{
    [Serializable]
    internal abstract class Spell
    {
        protected readonly SaveGame SaveGame;

        protected Spell(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }

        /// <summary>
        /// Returns true, if the spell has been forgotten because the players level dropped to low.  When true, Learned is set to false.
        /// </summary>
        public bool Forgotten;

        /// <summary>
        /// Returns true, if the spell has been learned.  Once a spell is learned, forgetting the spell returns this value to false and sets the Forgotten property
        /// to true.
        /// </summary>
        public bool Learned;

        /// <summary>
        /// Returns the name of the spell, as rendered to the SaveGame.Player.
        /// </summary>
        public abstract string Name { get; }

        public bool Worked;

        public int FirstCastExperience
        {
            get; protected set;
        }

        public int Level
        {
            get; protected set;
        }

        public int ManaCost
        {
            get; protected set;
        }

        protected int BaseFailure
        {
            get; set;
        }

        public abstract void Cast();

        public int FailureChance() 
        {
            BaseCharacterClass baseCharacterClass = SaveGame.Player.BaseCharacterClass;
            if (baseCharacterClass.SpellCastingType == null)
            {
                return 100;
            }
            int chance = BaseFailure;
            chance -= 3 * (SaveGame.Player.Level - Level);
            chance -= 3 * (SaveGame.Player.AbilityScores[baseCharacterClass.SpellStat].SpellFailureReduction - 1);
            if (ManaCost > SaveGame.Player.Mana)
            {
                chance += 5 * (ManaCost - SaveGame.Player.Mana);
            }
            int minfail = SaveGame.Player.AbilityScores[baseCharacterClass.SpellStat].SpellMinFailChance;
            if (baseCharacterClass.ID != CharacterClass.Priest && baseCharacterClass.ID != CharacterClass.Druid &&
                baseCharacterClass.ID != CharacterClass.Mage && baseCharacterClass.ID != CharacterClass.HighMage &&
                baseCharacterClass.ID != CharacterClass.Cultist)
            {
                if (minfail < 5)
                {
                    minfail = 5;
                }
            }
            if ((baseCharacterClass.ID == CharacterClass.Priest || baseCharacterClass.ID == CharacterClass.Druid) && SaveGame.Player.HasUnpriestlyWeapon)
            {
                chance += 25;
            }
            if (baseCharacterClass.ID == CharacterClass.Cultist && SaveGame.Player.HasUnpriestlyWeapon)
            {
                chance += 25;
            }
            if (chance < minfail)
            {
                chance = minfail;
            }
            if (SaveGame.Player.TimedStun.TurnsRemaining > 50)
            {
                chance += 25;
            }
            else if (SaveGame.Player.TimedStun.TurnsRemaining != 0)
            {
                chance += 15;
            }
            if (chance > 95)
            {
                chance = 95;
            }
            return chance;
        }

        /// <summary>
        /// Returns detailed information about the spell.
        /// </summary>
        /// <returns></returns>
        public string GetInfo()
        {
            if (Forgotten)
            {
                return "forgotten";
            }
            if (!Learned)
            {
                return "unknown";
            }
            string spellComment = Info() ?? "";
            return !Worked ? "untried" : spellComment;
        }

        public void Initialize(BaseCharacterClass characterClass)
        {
            foreach (ClassSpell classSpell in SaveGame.SingletonRepository.ClassSpells)
            {
                // TODO: This needs to use a dual dictionary for fast lookup
                if (classSpell.Spell.Name == this.GetType().Name && classSpell.CharacterClass.Name == characterClass.GetType().Name)
                {
                    Level = classSpell.Level;
                    ManaCost = classSpell.ManaCost;
                    BaseFailure = classSpell.BaseFailure;
                    FirstCastExperience = classSpell.FirstCastExperience;
                    return;
                }
            }

            // Character class does not have access to this spell.
            // TODO: This should never happen.
            throw new Exception("Spell does not have a configuration for this character class.");
            //Level = 99;
            //ManaCost = 0;
            //BaseFailure = 0;
            //FirstCastExperience = 0;
        }

        public string SummaryLine()
        {
            return Level >= 99 ? "(illegible)" : $"{Name,-30} {Level,3} {ManaCost,4} {FailureChance(),3}% {GetInfo()}";
        }

        public override string ToString()
        {
            return $"{Name} ({Level}, {ManaCost}, {BaseFailure}, {FirstCastExperience})";
        }

        /// <summary>
        /// Returns information about the spell.  If there is no detailed information, null is returned.  Returns null, by default.
        /// </summary>
        /// <returns></returns>
        protected virtual string? Info() => null;
    }
}