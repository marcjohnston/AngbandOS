// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class GoodOrbOfLightEnchantmentScript : Script, IEnhancementScript
{
    private GoodOrbOfLightEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        WeightedRandom<ItemEnhancement> weightedRandom = new WeightedRandom<ItemEnhancement>(Game);
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfAcidItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfLightningItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfLightItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfDarknessItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfLifeItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfSightItemEnhancement)));
        weightedRandom.Add(2, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfCourageItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfVenomItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfClarityItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfSoundItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfChaosItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfShardsItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfUnlifeItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfStabilityItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfMagicItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfFreedomItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfStrengthItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfWisdomItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfFlameItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfDexterityItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfConstitutionItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfIntelligenceItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfCharismaItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfLightnessItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfInsightItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfTheMindItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfSustenanceItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfHealthItemEnhancement)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfFrostItemEnhancement)));
        item.SetRareItem(weightedRandom.ChooseOrDefault());
    }
}
