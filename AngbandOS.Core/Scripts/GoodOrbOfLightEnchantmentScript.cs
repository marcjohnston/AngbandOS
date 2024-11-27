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
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfAcidRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfLightningRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfLightRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfDarknessRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfLifeRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfSightRareItem)));
        weightedRandom.Add(2, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfCourageRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfVenomRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfClarityRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfSoundRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfChaosRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfShardsRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfUnlifeRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfStabilityRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfMagicRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfFreedomRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfStrengthRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfWisdomRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfFlameRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfDexterityRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfConstitutionRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfIntelligenceRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfCharismaRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfLightnessRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfInsightRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfTheMindRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfSustenanceRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfHealthRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfFrostRareItem)));
        item.RareItem = weightedRandom.ChooseOrDefault();
    }
}
