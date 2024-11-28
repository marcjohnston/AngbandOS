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
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponElderSignInscribedRareItem));
                if (Game.DieRoll(4) == 1)
                {
                    item.Characteristics.Blows = true;
                    if (item.Characteristics.BonusAttacks > 2)
                    {
                        item.Characteristics.BonusAttacks -= Game.DieRoll(2);
                    }
                }
                break;
            case 2:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponDefenderRareItem));
                if (Game.DieRoll(3) == 1)
                {
                    item.Characteristics.ResPois = true;
                }
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactEnhancementBundleWeightedRandom)));
                break;
            case 3:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfVitriolRareItem));
                break;
            case 4:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfShockingRareItem));
                break;
            case 5:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfBurningRareItem));
                break;
            case 6:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfFreezingRareItem));
                break;
            case 7:
            case 8:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayAnimalRareItem));
                if (Game.RandomLessThan(100) < 20)
                {
                    item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfAnimalBaneRareItem));
                }
                break;
            case 9:
            case 10:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayDragonRareItem));
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(NaturalResistanceItemEnhancementWeightedRandom)));
                if (Game.RandomLessThan(100) < 20)
                {
                    if (Game.DieRoll(3) == 1)
                    {
                        item.Characteristics.ResPois = true;
                    }
                    item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(NaturalAndPoisonResistanceItemEnhancementWeightedRandom)));
                    item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfDragonBaneRareItem));
                }
                break;
            case 11:
            case 12:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayEvilRareItem));
                if (Game.RandomLessThan(100) < 20)
                {
                    item.Characteristics.ResFear = true;
                    item.Characteristics.Blessed = true;
                    item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfEvilBaneRareItem));
                }
                break;
            case 13:
            case 14:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayUndeadRareItem));
                if (Game.RandomLessThan(100) < 20)
                {
                    item.Characteristics.ResNether = true;
                    item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfUndeadBaneRareItem));
                }
                break;
            case 15:
            case 16:
            case 17:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayOrcRareItem));
                break;
            case 18:
            case 19:
            case 20:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayTrollRareItem));
                break;
            case 21:
            case 22:
            case 23:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayGiantRareItem));
                break;
            case 24:
            case 25:
            case 26:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayDemonRareItem));
                break;
            case 27:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfKadathRareItem));
                if (Game.DieRoll(3) == 1)
                {
                    item.Characteristics.ResFear = true;
                }
                break;
            case 28:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponBlessedRareItem));
                break;
            case 29:
            case 30:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfExtraAttacksRareItem));
                break;
            case 31:
            case 32:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponVampiricRareItem));
                break;
            case 33:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfPoisoningRareItem));
                break;
            case 34:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponChaoticRareItem));
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(ResistanceAndBiasItemEnhancementWeightedRandom)));
                break;
            case 35:
                item.CreateRandomArtifact(false);
                break;
            case 36:
            case 37:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayingRareItem));
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
                    item.Characteristics.BrandPois = true;
                }
                if (item.CapableOfVorpalSlaying && Game.DieRoll(3) == 1)
                {
                    item.Characteristics.Vorpal = true;
                }
                break;
            case 38:
            case 39:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponPlanarWeaponRareItem));
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactEnhancementBundleWeightedRandom)));
                if (Game.DieRoll(5) == 1)
                {
                    item.Characteristics.SlayDemon = true;
                }
                break;
            case 40:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfLawRareItem));
                if (Game.DieRoll(3) == 1)
                {
                    item.Characteristics.HoldLife = true;
                }
                if (Game.DieRoll(3) == 1)
                {
                    item.Characteristics.Dex = true;
                }
                if (Game.DieRoll(5) == 1)
                {
                    item.Characteristics.ResFear = true;
                }
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactEnhancementBundleWeightedRandom)));
                break;
            case 41:
            case 42:
                if (item.CanBeWeaponOfSharpness)
                {
                    item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSharpnessRareItem));
                    item.Characteristics.BonusTunnel = item.GetBonusValue(5, level) + 1;
                }
                else
                {
                    item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfEarthquakesRareItem));
                    if (Game.DieRoll(3) == 1)
                    {
                        item.Characteristics.Blows = true;
                    }
                    item.Characteristics.BonusTunnel = item.GetBonusValue(3, level);
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
