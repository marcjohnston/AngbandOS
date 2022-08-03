using Cthangband.ArtifactBiases;
using Cthangband.Enumerations;

namespace Cthangband.ItemCategories
{
    internal interface IItemCategory
    {
        /// <summary>
        /// Returns the ItemCategoryEnum value for backwards compatibility.  This property will be deleted.
        /// </summary>
        ItemCategory CategoryEnum { get; }

        ///// <summary>
        ///// Returns true, if the item is capable of having a bonus armour class applied.  Only weapons return true.  Returns false by default.
        ///// </summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //bool CanHaveBonusArmourClass { get; }

        ///// <summary>
        ///// Returns true, if the item is capable of having slaying bonuses applied.  Only weapons return true.  Returns false by default.
        ///// </summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //bool CanSlay { get; }

        /// <summary>
        /// Returns true, if the item can apply a tunnel bonus.  Only weapons, return true.  Returns false, by default.
        /// </summary>
        bool CanApplyTunnelBonus { get; }

        /// <summary>
        /// Returns true, if the item is capable of vorpal slaying.  Only swords return true.  Returns false, by default.
        /// </summary>
        bool CanVorpalSlay { get; }

        /// <summary>
        /// Returns true, if the item can apply a bonus armour class for miscellaneous power.  Only weapons return true.  Returns false, by default.
        /// </summary>
        bool CanApplyBonusArmourClassMiscPower { get; }

        /// <summary>
        /// Returns true, if the item can apply a blows bonus.  All weapons, except for the bow, return true.  Returns false, by default.
        /// </summary>
        bool CanApplyBlowsBonus { get; }

        void ApplyRandomSlaying(ref IArtifactBias artifactBias, Item item);

        /// <summary>
        /// Returns a description for the item.  Returns a macro processed description, by default.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="includeCountPrefix">Specify true, to include the number of items as the prefix; false, to excluse the count.  Pluralization will still
        /// occur when the count is not included.</param>
        /// <returns></returns>
        string GetDescription(Item item, bool includeCountPrefix);

        /// <summary>
        /// Returns an additional description of the item that is appended to the base description, when needed.  Returns string.empty by default.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        string GetDetailedDescription(Item item);

        /// <summary>
        /// Returns an additional description of the item that is appended to the detailed description, when needed.  
        /// By default, empty is returned, if the item is known; otherwise, the HideType, Speed, Blows, Stealth, Search, Infra, Tunnel and recharging time characteristics are returned.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        string GetVerboseDescription(Item item);

        /// <summary>
        /// Returns an additional description to fully identify the item that is appended to the verbode description, when needed.  
        /// By default, returns the description for inscriptions, cursed, empty, tried and on discount.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        string GetFullDescription(Item item);

        /// <summary>
        /// Gets an additional bonus gold real value associated with the item.  Returns a type specific value by default.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        int GetBonusRealValue(Item item, int value);

        /// <summary>
        /// Returns true, if the item is deemed as worthless.  Worthless items will ignore their RealValue and will always have 0 real value.  Returns false by default.
        /// </summary>
        bool IsWorthless(Item item);

        /// <summary>
        /// Returns a description of the items' activation.  Returns null by default.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        string DescribeActivationEffect(Item item);

        /// <summary>
        /// Returns an additional description when identified fully.  Returns null by default.  Only light sources provide an additional description.
        /// </summary>
        string Identify(Item item);

        /// <summary>
        /// Returns the base value for a non flavor-aware item.  Returns 0, by default.
        /// </summary>
        int BaseValue { get; }

        /// <summary>
        /// Returns true, if the item is susceptible to electricity.  Returns false, by default.
        /// </summary>
        bool HatesElectricity { get; }

        /// <summary>
        /// Returns true, if the item is susceptible to fire.  Returns false, by default.
        /// </summary>
        bool HatesFire { get; }

        /// <summary>
        /// Returns true, if the item is susceptible to acid.  Returns false, by default.
        /// </summary>
        bool HatesAcid { get; }

        /// <summary>
        /// Returns true, if the item is susceptible to cold.  Returns false, by default.
        /// </summary>
        bool HatesCold { get; }

        ///// <summary>
        ///// Returns true, if the item can absorb other items of the same type.  Returns false, by default.
        ///// </summary>
        //bool CanAbsorb { get; }

        /// <summary>
        /// Returns the percentage chance that an thrown or fired item breaks.  Returns 10, or 10%, by default.  A value of 101, guarantees the item will break.
        /// </summary>
        int PercentageBreakageChance { get; }

        /// <summary>
        /// Returns true, if the item multiplies damages against a specific monster race.  Returns false, by default. Shots, arrows, bolts, hafted, polearms, swords and digging all return true.
        /// </summary>
        bool GetsDamageMultiplier { get; }

        /// <summary>
        /// Returns a count for the number of items to create during the MakeObject.  Returns 1, by default.  Spikes, shots, arrows and bolts return values greater than 1.
        /// </summary>
        int MakeObjectCount { get; }

        /// <summary>
        /// Returns true, if the item can provide a sheath of electricity.  Returns false, by default.  Cloaks, soft and hard armor return true.
        /// </summary>
        bool CanProvideSheathOfElectricity { get; }

        /// <summary>
        /// Returns true, if the item can provide a sheath of fire.  Returns false, by default.  Cloaks, soft and hard armor return true.
        /// </summary>
        bool CanProvideSheathOfFire { get; }

        /// <summary>
        /// Returns true, if the item can reflect bolts and arrows.  Returns false, by default.  Shields, helms, cloaks and hard armor return true.
        /// </summary>
        bool CanReflectBoltsAndArrows { get; }

        ///// <summary>
        ///// Returns true, if the item is ignored by monsters.  Only gold is ignored and returns true.
        ///// </summary>
        //bool IgnoredByMonsters { get; }

        ///// <summary>
        ///// Returns true, if the item has charges.  Staffs and wands return true.
        ///// </summary>
        //bool IsCharged { get; }

        ///// <summary>
        ///// Returns true, if the item can be eaten.  Only food returns true.
        ///// </summary>
        //bool CanBeConsumed { get; }

        /// <summary>
        /// Returns the color to be used to render the item for its description.  White is provided by default.
        /// </summary>
        Colour Colour { get; }

        /// <summary>
        /// Applies magic to the item.  Does nothing, by default.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="level"></param>
        /// <param name="power"></param>
        void ApplyMagic(Item item, int level, int power);
    }
}
