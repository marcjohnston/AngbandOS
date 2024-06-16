// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


namespace AngbandOS.Core.ItemFactories;

/// <summary>
/// Represents common characteristics for melee weapons.  Hafted, polearm and swords are all melee weapons.
/// </summary>
[Serializable]
internal abstract class MeleeWeaponItemFactory : WeaponItemFactory
{
    /// <summary>
    /// Returns the melee weapon inventory slot for melee weapons.
    /// </summary>
    public override int WieldSlot => InventorySlot.MeleeWeapon;

    public MeleeWeaponItemFactory(Game game) : base(game) { }
    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.Get<BaseInventorySlot>(nameof(MeleeWeaponInventorySlot));
    public override bool GetsDamageMultiplier => true;

    protected virtual bool CanBeWeaponOfLaw => false;
    protected virtual bool CanBeWeaponOfSharpness => false;
    protected virtual bool CapableOfVorpalSlaying => false;
    public override void EnchantItem(Item item, bool usedOkay, int level, int power)
    {
        base.EnchantItem(item, usedOkay, level, power);
        if (power > 1)
        {
            switch (Game.DieRoll(CanBeWeaponOfLaw || CanBeWeaponOfSharpness ? 42 : 40))
            {
                case 1:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponElderSignInscribedRareItem));
                    if (Game.DieRoll(4) == 1)
                    {
                        item.Characteristics.Blows = true;
                        if (item.BonusAttacks > 2)
                        {
                            item.BonusAttacks -= Game.DieRoll(2);
                        }
                    }
                    break;
                case 2:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponDefenderRareItem));
                    if (Game.DieRoll(3) == 1)
                    {
                        item.Characteristics.ResPois = true;
                    }
                    item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
                    break;
                case 3:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfVitriolRareItem));
                    break;
                case 4:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfShockingRareItem));
                    break;
                case 5:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfBurningRareItem));
                    break;
                case 6:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfFreezingRareItem));
                    break;
                case 7:
                case 8:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfSlayAnimalRareItem));
                    if (Game.RandomLessThan(100) < 20)
                    {
                        item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfAnimalBaneRareItem));
                    }
                    break;
                case 9:
                case 10:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfSlayDragonRareItem));
                    item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(NaturalResistanceItemAdditiveBundleWeightedRandom)));
                    if (Game.RandomLessThan(100) < 20)
                    {
                        if (Game.DieRoll(3) == 1)
                        {
                            item.Characteristics.ResPois = true;
                        }
                        item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(NaturalAndPoisonResistanceItemAdditiveBundleWeightedRandom)));
                        item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfDragonBaneRareItem));
                    }
                    break;
                case 11:
                case 12:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfSlayEvilRareItem));
                    if (Game.RandomLessThan(100) < 20)
                    {
                        item.Characteristics.ResFear = true;
                        item.Characteristics.Blessed = true;
                        item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfEvilBaneRareItem));
                    }
                    break;
                case 13:
                case 14:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfSlayUndeadRareItem));
                    item.Characteristics.HoldLife = true;
                    if (Game.RandomLessThan(100) < 20)
                    {
                        item.Characteristics.ResNether = true;
                        item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfUndeadBaneRareItem));
                    }
                    break;
                case 15:
                case 16:
                case 17:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfSlayOrcRareItem));
                    break;
                case 18:
                case 19:
                case 20:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfSlayTrollRareItem));
                    break;
                case 21:
                case 22:
                case 23:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfSlayGiantRareItem));
                    break;
                case 24:
                case 25:
                case 26:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfSlayDemonRareItem));
                    break;
                case 27:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfKadathRareItem));
                    if (Game.DieRoll(3) == 1)
                    {
                        item.Characteristics.ResFear = true;
                    }
                    break;
                case 28:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponBlessedRareItem));
                    break;
                case 29:
                case 30:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfExtraAttacksRareItem));
                    break;
                case 31:
                case 32:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponVampiricRareItem));
                    break;
                case 33:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfPoisoningRareItem));
                    break;
                case 34:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponChaoticRareItem));
                    item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(ResistanceAndBiasItemAdditiveBundleWeightedRandom)));
                    break;
                case 35:
                    item.CreateRandomArtifact(false);
                    break;
                case 36:
                case 37:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfSlayingRareItem));
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
                    if (CapableOfVorpalSlaying && Game.DieRoll(3) == 1)
                    {
                        item.Characteristics.Vorpal = true;
                    }
                    break;
                case 38:
                case 39:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponPlanarWeaponRareItem));
                    item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
                    if (Game.DieRoll(5) == 1)
                    {
                        item.Characteristics.SlayDemon = true;
                    }
                    break;
                case 40:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfLawRareItem));
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
                    item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
                    break;
                case 41:
                case 42:
                    if (CanBeWeaponOfSharpness)
                    {
                        item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfSharpnessRareItem));
                        item.BonusTunnel = item.GetBonusValue(5, level) + 1;
                    }
                    else
                    {
                        item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfEarthquakesRareItem));
                        if (Game.DieRoll(3) == 1)
                        {
                            item.Characteristics.Blows = true;
                        }
                        item.BonusTunnel = item.GetBonusValue(3, level);
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
        else if (power < -1)
        {
            if (Game.RandomLessThan(Constants.MaxDepth) < level)
            {
                item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(WeaponOfLengRareItem));
                if (Game.DieRoll(6) == 1)
                {
                    item.Characteristics.DreadCurse = true;
                }
            }
        }
    }
}
