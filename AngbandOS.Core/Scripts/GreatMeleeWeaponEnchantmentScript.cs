// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class GreatMeleeWeaponEnchantmentScript : Script, IEnhancementScript
{
    private GreatMeleeWeaponEnchantmentScript(Game game) : base(game) { }

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
        switch (Game.DieRoll(item.CanBeWeaponOfLaw || item.CanBeWeaponOfSharpness ? 42 : 40))
        {
            case 1:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponElderSignInscribedItemEnhancement));
                if (Game.DieRoll(4) == 1)
                {
                    item.EnchantmentItemProperties.Blows = true;
                    if (item.EnchantmentItemProperties.BonusAttacks > 2)
                    {
                        item.EnchantmentItemProperties.BonusAttacks -= Game.DieRoll(2);
                    }
                }
                break;
            case 2:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponDefenderItemEnhancement));
                if (Game.DieRoll(3) == 1)
                {
                    item.EnchantmentItemProperties.ResPois = true;
                }
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactItemEnhancementWeightedRandom)));
                break;
            case 3:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfVitriolItemEnhancement));
                break;
            case 4:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfShockingItemEnhancement));
                break;
            case 5:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfBurningItemEnhancement));
                break;
            case 6:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfFreezingItemEnhancement));
                break;
            case 7:
            case 8:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayAnimalItemEnhancement));
                if (Game.RandomLessThan(100) < 20)
                {
                    item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfAnimalBaneItemEnhancement));
                }
                break;
            case 9:
            case 10:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayDragonItemEnhancement));
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(NaturalResistanceItemEnhancementWeightedRandom)));
                if (Game.RandomLessThan(100) < 20)
                {
                    if (Game.DieRoll(3) == 1)
                    {
                        item.EnchantmentItemProperties.ResPois = true;
                    }
                    item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(NaturalAndPoisonResistanceItemEnhancementWeightedRandom)));
                    item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfDragonBaneItemEnhancement));
                }
                break;
            case 11:
            case 12:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayEvilItemEnhancement));
                if (Game.RandomLessThan(100) < 20)
                {
                    item.EnchantmentItemProperties.ResFear = true;
                    item.EnchantmentItemProperties.Blessed = true;
                    item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfEvilBaneItemEnhancement));
                }
                break;
            case 13:
            case 14:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayUndeadItemEnhancement));
                if (Game.RandomLessThan(100) < 20)
                {
                    item.EnchantmentItemProperties.ResNether = true;
                    item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfUndeadBaneItemEnhancement));
                }
                break;
            case 15:
            case 16:
            case 17:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayOrcItemEnhancement));
                break;
            case 18:
            case 19:
            case 20:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayTrollItemEnhancement));
                break;
            case 21:
            case 22:
            case 23:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayGiantItemEnhancement));
                break;
            case 24:
            case 25:
            case 26:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayDemonItemEnhancement));
                break;
            case 27:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfKadathItemEnhancement));
                if (Game.DieRoll(3) == 1)
                {
                    item.EnchantmentItemProperties.ResFear = true;
                }
                break;
            case 28:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponBlessedItemEnhancement));
                break;
            case 29:
            case 30:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfExtraAttacksItemEnhancement));
                break;
            case 31:
            case 32:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponVampiricItemEnhancement));
                break;
            case 33:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfPoisoningItemEnhancement));
                break;
            case 34:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponChaoticItemEnhancement));
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(ResistanceAndBiasItemEnhancementWeightedRandom)));
                break;
            case 35:
                item.CreateRandomArtifact(false);
                break;
            case 36:
            case 37:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayingItemEnhancement));
                if (Game.DieRoll(3) == 1)
                {
                    item.DamageDice *= 2;
                }
                else
                {
                    do
                    {
                        item.DamageDice++;
                    } while (Game.DieRoll(item.DamageDice) == 1);
                    do
                    {
                        item.DamageSides++;
                    } while (Game.DieRoll(item.DamageSides) == 1);
                }
                if (Game.DieRoll(5) == 1)
                {
                    item.EnchantmentItemProperties.BrandPois = true;
                }
                if (item.CapableOfVorpalSlaying && Game.DieRoll(3) == 1)
                {
                    item.EnchantmentItemProperties.Vorpal = true;
                }
                break;
            case 38:
            case 39:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponPlanarWeaponItemEnhancement));
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactItemEnhancementWeightedRandom)));
                if (Game.DieRoll(5) == 1)
                {
                    item.EnchantmentItemProperties.SlayDemon = true;
                }
                break;
            case 40:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfLawItemEnhancement));
                if (Game.DieRoll(3) == 1)
                {
                    item.EnchantmentItemProperties.HoldLife = true;
                }
                if (Game.DieRoll(3) == 1)
                {
                    item.EnchantmentItemProperties.Dex = true;
                }
                if (Game.DieRoll(5) == 1)
                {
                    item.EnchantmentItemProperties.ResFear = true;
                }
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactItemEnhancementWeightedRandom)));
                break;
            case 41:
            case 42:
                if (item.CanBeWeaponOfSharpness)
                {
                    item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSharpnessItemEnhancement));
                    item.EnchantmentItemProperties.BonusTunnel = item.GetBonusValue(5, level) + 1;
                }
                else
                {
                    item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfEarthquakesItemEnhancement));
                    if (Game.DieRoll(3) == 1)
                    {
                        item.EnchantmentItemProperties.Blows = true;
                    }
                    item.EnchantmentItemProperties.BonusTunnel = item.GetBonusValue(3, level);
                }
                break;
        }
        while (Game.RandomLessThan(10 * item.DamageDice * item.DamageSides) == 0)
        {
            item.DamageDice++;
        }
        if (item.DamageDice > 9)
        {
            item.DamageDice = 9;
        }
    }
}
