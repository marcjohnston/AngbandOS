// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Reflection.PortableExecutable;

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
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponElderSignInscribedItemEnhancement)));
                if (Game.DieRoll(4) == 1)
                {
                    item.EffectivePropertySet.BonusAttacks++;
                    if (item.EffectivePropertySet.BonusAttacks > 2)
                    {
                        item.EffectivePropertySet.BonusAttacks -= Game.DieRoll(2);
                    }
                }
                break;
            case 2:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponDefenderItemEnhancement)));
                if (Game.DieRoll(3) == 1)
                {
                    item.EffectivePropertySet.ResPois = true;
                }
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactItemEnhancementWeightedRandom)));
                break;
            case 3:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfVitriolItemEnhancement)));
                break;
            case 4:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfShockingItemEnhancement)));
                break;
            case 5:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfBurningItemEnhancement)));
                break;
            case 6:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfFreezingItemEnhancement)));
                break;
            case 7:
            case 8:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayAnimalItemEnhancement)));
                if (Game.RandomLessThan(100) < 20)
                {
                    item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfAnimalBaneItemEnhancement)));
                }
                break;
            case 9:
            case 10:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayDragonItemEnhancement)));
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(NaturalResistanceItemEnhancementWeightedRandom)));
                if (Game.RandomLessThan(100) < 20)
                {
                    if (Game.DieRoll(3) == 1)
                    {
                        item.EffectivePropertySet.ResPois = true;
                    }
                    item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(NaturalAndPoisonResistanceItemEnhancementWeightedRandom)));
                    item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfDragonBaneItemEnhancement)));
                }
                break;
            case 11:
            case 12:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayEvilItemEnhancement)));
                if (Game.RandomLessThan(100) < 20)
                {
                    item.EffectivePropertySet.ResFear = true;
                    item.EffectivePropertySet.Blessed = true;
                    item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfEvilBaneItemEnhancement)));
                }
                break;
            case 13:
            case 14:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayUndeadItemEnhancement)));
                if (Game.RandomLessThan(100) < 20)
                {
                    item.EffectivePropertySet.ResNether = true;
                    item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfUndeadBaneItemEnhancement)));
                }
                break;
            case 15:
            case 16:
            case 17:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayOrcItemEnhancement)));
                break;
            case 18:
            case 19:
            case 20:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayTrollItemEnhancement)));
                break;
            case 21:
            case 22:
            case 23:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayGiantItemEnhancement)));
                break;
            case 24:
            case 25:
            case 26:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayDemonItemEnhancement)));
                break;
            case 27:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfKadathItemEnhancement)));
                if (Game.DieRoll(3) == 1)
                {
                    item.EffectivePropertySet.ResFear = true;
                }
                break;
            case 28:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponBlessedItemEnhancement)));
                break;
            case 29:
            case 30:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfExtraAttacksItemEnhancement)));
                break;
            case 31:
            case 32:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponVampiricItemEnhancement)));
                break;
            case 33:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfPoisoningItemEnhancement)));
                break;
            case 34:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponChaoticItemEnhancement)));
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(ResistanceAndBiasItemEnhancementWeightedRandom)));
                break;
            case 35:
                item.CreateRandomArtifact(false);
                break;
            case 36:
            case 37:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSlayingItemEnhancement)));
                if (Game.DieRoll(3) == 1)
                {
                    item.EffectivePropertySet.DamageDice *= 2;
                }
                else
                {
                    do
                    {
                        item.EffectivePropertySet.AddIntValue(AttributeEnum.DamageDice, 1);

                    } while (Game.DieRoll(item.EffectivePropertySet.DamageDice) == 1);
                    do
                    {
                        item.EffectivePropertySet.DiceSides++;
                    } while (Game.DieRoll(item.EffectivePropertySet.DiceSides) == 1);
                }
                if (Game.DieRoll(5) == 1)
                {
                    item.EffectivePropertySet.BrandPois = true;
                }
                if (item.CapableOfVorpalSlaying && Game.DieRoll(3) == 1)
                {
                    item.EffectivePropertySet.SetIntValue(AttributeEnum.Vorpal1InChance, 2);
                }
                break;
            case 38:
            case 39:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponPlanarWeaponItemEnhancement)));
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactItemEnhancementWeightedRandom)));
                if (Game.DieRoll(5) == 1)
                {
                    item.EffectivePropertySet.SlayDemon = true;
                }
                break;
            case 40:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfLawItemEnhancement)));
                if (Game.DieRoll(3) == 1)
                {
                    item.EffectivePropertySet.HoldLife = true;
                }
                if (Game.DieRoll(3) == 1)
                {
                    item.EffectivePropertySet.BonusDexterity = Game.EnchantBonus(item.EffectivePropertySet.BonusDexterity);
                }
                if (Game.DieRoll(5) == 1)
                {
                    item.EffectivePropertySet.ResFear = true;
                }
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactItemEnhancementWeightedRandom)));
                break;
            case 41:
            case 42:
                if (item.CanBeWeaponOfSharpness)
                {
                    item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfSharpnessItemEnhancement)));
                    item.EffectivePropertySet.BonusTunnel = item.GetBonusValue(5, level) + 1;
                }
                else
                {
                    item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponOfEarthquakesItemEnhancement)));
                    if (Game.DieRoll(3) == 1)
                    {
                        item.EffectivePropertySet.BonusAttacks++;
                    }
                    item.EffectivePropertySet.BonusTunnel = item.GetBonusValue(3, level);
                }
                break;
        }
        while (Game.RandomLessThan(10 * item.EffectivePropertySet.DamageDice * item.EffectivePropertySet.DiceSides) == 0)
        {
            item.EffectivePropertySet.AddIntValue(AttributeEnum.DamageDice, 1);
        }
        if (item.EffectivePropertySet.DamageDice > 9)
        {
            item.EffectivePropertySet.OverrideIntValue(AttributeEnum.DamageDice, 9);
        }
    }
}
