// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Races;

[Serializable]
internal abstract class Race : IGetKey
{
    protected readonly Game Game;
    protected Race(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }


    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public virtual void Bind() { }

    public abstract int[] AbilityBonus { get; } // TODO: This needs to be a dictionary where the keys are stats
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
    /// Returns the description for the race.  The description is multi-line and has word-breaking macros \n built-in.  The description supports up to 6 lines.
    /// </summary>
    public abstract string Description { get; }

    /// <summary>
    /// Returns the PlayerHistory (Game._backgroundTable) group used to produce the backstory fragments that are joined together on character generation.  Returns
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
            name = syllables.BeginningSyllables[Game.RandomLessThan(syllables.BeginningSyllables.Length)];
            name += syllables.MiddleSyllables[Game.RandomLessThan(syllables.MiddleSyllables.Length)];
            name += syllables.EndingSyllables[Game.RandomLessThan(syllables.EndingSyllables.Length)];
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

    public virtual void CalcBonuses()
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
    /// Allows the race to process world.  Does nothing by default.  Vampire races override this method to take a hit when exposed to sunlight.
    /// </summary>
    /// <param name="processWorldEventArgs"></param>
    public virtual void ProcessWorld(ProcessWorldEventArgs processWorldEventArgs) { }

    /// <summary>
    /// Returns true, if the race is damaged by darkness.  Returns true, by default.  Only vampires return false.
    /// </summary>
    public virtual bool IsDamagedByDarkness => true;

    /// <summary>
    /// Allow the race to consume food.  The full value of the food item is gained, by default.  Vampires and spectres override this for lower than full nutritional value.
    /// </summary>
    /// <param name="game"></param>
    /// <param name="item"></param>
    public virtual void Eat(Item item)
    {
        // Everyone else gets the full value
        Game.SetFood(Game.Food.IntValue + item.NutritionalValue);
    }

    /// <summary>
    /// Allow the race to quaff a potion.  Does nothing by default.  Skeletons are messy drinkers.
    /// </summary>
    /// <param name="game"></param>
    /// <param name="item"></param>
    public virtual void Quaff(ItemFactory itemFactory) { }

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

    public virtual void UseRacialPower()
    {
        // Other races don't have powers
        Game.MsgPrint("This race has no bonus power.");
        Game.EnergyUse = 0;
    }

    /// <summary>
    /// Returns true, if characters are automatically outfitted with scrolls of satisfy hunger.  Golems, skeletons, zombies, vampires and spectres return 
    /// true.  Returns false by default.
    /// </summary>
    public virtual bool OutfitsWithScrollsOfSatisfyHunger => false;

    /// <summary>
    /// Returns true, if characters are automatically outfitted with scrolls of light.  Vampires and spectres return 
    /// true.  Returns false by default.
    /// </summary>
    public virtual bool OutfitsWithScrollsOfLight => false;

    /// <summary>
    /// Return true, if the race automatically gains the first level mutation upon birth.  Only MiriNigri races return true.  Returns false, by default.
    /// </summary>
    public virtual bool AutomaticallyGainsFirstLevelMutationAtBirth => false;

    /// <summary>
    /// Returns a chance (0-100) of the race being immune to a sanity blast.  A chance of 100, means the race is not affected by the sanity blast.  Imps
    /// and mind flayers return 100. Skeletons, zombies, vampires and spectres all return a chance of the players' level + 25.  Returns 0, by default.
    /// </summary>
    public virtual int ChanceOfSanityBlastImmunity(int level) => 0;

    /// <summary>
    /// Returns true, if the race can be stunned.  Returns false, by default.  Only golems return false.
    /// </summary>
    public virtual bool CanBeStunned => true;

    /// <summary>
    /// Allows the race to modify an item class when the character is being outfitted.  Returns the original item class, by default.  Only the tcho-tcho
    /// race upgrades a ring of resist fear to a ring of sustain strength.
    /// </summary>
    /// <param name="item"></param>
    public virtual ItemFactory OutfitItemClass(ItemFactory item)
    {
        return item;
    }
}
