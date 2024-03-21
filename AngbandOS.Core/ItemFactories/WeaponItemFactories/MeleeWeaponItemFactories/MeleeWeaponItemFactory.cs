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
    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.InventorySlots.Get(nameof(MeleeWeaponInventorySlot));
    public override bool GetsDamageMultiplier => true;

    protected virtual bool CanBeWeaponOfLaw => false;
    protected virtual bool CanBeWeaponOfSharpness => false;
    protected virtual bool CapableOfVorpalSlaying => false;
    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        base.ApplyMagic(item, level, power, null);
        if (power > 1)
        {
            IArtifactBias artifactBias = null;
            switch (Game.DieRoll(CanBeWeaponOfLaw || CanBeWeaponOfSharpness ? 42 : 40))
            {
                case 1:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponElderSignInscribedRareItem));
                    if (Game.DieRoll(4) == 1)
                    {
                        item.RandomArtifactItemCharacteristics.Blows = true;
                        if (item.TypeSpecificValue > 2)
                        {
                            item.TypeSpecificValue -= Game.DieRoll(2);
                        }
                    }
                    break;
                case 2:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponDefenderRareItem));
                    if (Game.DieRoll(3) == 1)
                    {
                        item.RandomArtifactItemCharacteristics.ResPois = true;
                    }
                    item.ApplyRandomResistance(ref artifactBias, Game.DieRoll(22) + 16);
                    break;
                case 3:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfVitriolRareItem));
                    break;
                case 4:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfShockingRareItem));
                    break;
                case 5:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfBurningRareItem));
                    break;
                case 6:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfFreezingRareItem));
                    break;
                case 7:
                case 8:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfSlayAnimalRareItem));
                    if (Game.RandomLessThan(100) < 20)
                    {
                        item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfAnimalBaneRareItem));
                    }
                    break;
                case 9:
                case 10:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfSlayDragonRareItem));
                    item.ApplyRandomResistance(ref artifactBias, Game.DieRoll(12) + 4);
                    if (Game.RandomLessThan(100) < 20)
                    {
                        if (Game.DieRoll(3) == 1)
                        {
                            item.RandomArtifactItemCharacteristics.ResPois = true;
                        }
                        item.ApplyRandomResistance(ref artifactBias, Game.DieRoll(14) + 4);
                        item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfDragonBaneRareItem));
                    }
                    break;
                case 11:
                case 12:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfSlayEvilRareItem));
                    if (Game.RandomLessThan(100) < 20)
                    {
                        item.RandomArtifactItemCharacteristics.ResFear = true;
                        item.RandomArtifactItemCharacteristics.Blessed = true;
                        item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfEvilBaneRareItem));
                    }
                    break;
                case 13:
                case 14:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfSlayUndeadRareItem));
                    item.RandomArtifactItemCharacteristics.HoldLife = true;
                    if (Game.RandomLessThan(100) < 20)
                    {
                        item.RandomArtifactItemCharacteristics.ResNether = true;
                        item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfUndeadBaneRareItem));
                    }
                    break;
                case 15:
                case 16:
                case 17:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfSlayOrcRareItem));
                    break;
                case 18:
                case 19:
                case 20:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfSlayTrollRareItem));
                    break;
                case 21:
                case 22:
                case 23:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfSlayGiantRareItem));
                    break;
                case 24:
                case 25:
                case 26:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfSlayDemonRareItem));
                    break;
                case 27:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfKadathRareItem));
                    if (Game.DieRoll(3) == 1)
                    {
                        item.RandomArtifactItemCharacteristics.ResFear = true;
                    }
                    break;
                case 28:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponBlessedRareItem));
                    break;
                case 29:
                case 30:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfExtraAttacksRareItem));
                    break;
                case 31:
                case 32:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponVampiricRareItem));
                    break;
                case 33:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfPoisoningRareItem));
                    break;
                case 34:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponChaoticRareItem));
                    item.ApplyRandomResistance(ref artifactBias, Game.DieRoll(34) + 4);
                    break;
                case 35:
                    item.CreateRandomArtifact(false);
                    break;
                case 36:
                case 37:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfSlayingRareItem));
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
                            item.DamageDiceSides++;
                        } while (Game.DieRoll(item.DamageDiceSides) == 1);
                    }
                    if (Game.DieRoll(5) == 1)
                    {
                        item.RandomArtifactItemCharacteristics.BrandPois = true;
                    }
                    if (CapableOfVorpalSlaying && Game.DieRoll(3) == 1)
                    {
                        item.RandomArtifactItemCharacteristics.Vorpal = true;
                    }
                    break;
                case 38:
                case 39:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponPlanarWeaponRareItem));
                    item.ApplyRandomResistance(ref artifactBias, Game.DieRoll(22) + 16);
                    if (Game.DieRoll(5) == 1)
                    {
                        item.RandomArtifactItemCharacteristics.SlayDemon = true;
                    }
                    break;
                case 40:
                    item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfLawRareItem));
                    if (Game.DieRoll(3) == 1)
                    {
                        item.RandomArtifactItemCharacteristics.HoldLife = true;
                    }
                    if (Game.DieRoll(3) == 1)
                    {
                        item.RandomArtifactItemCharacteristics.Dex = true;
                    }
                    if (Game.DieRoll(5) == 1)
                    {
                        item.RandomArtifactItemCharacteristics.ResFear = true;
                    }
                    item.ApplyRandomResistance(ref artifactBias, Game.DieRoll(22) + 16);
                    break;
                case 41:
                case 42:
                    if (CanBeWeaponOfSharpness)
                    {
                        item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfSharpnessRareItem));
                        item.TypeSpecificValue = item.GetBonusValue(5, level) + 1;
                    }
                    else
                    {
                        item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfEarthquakesRareItem));
                        if (Game.DieRoll(3) == 1)
                        {
                            item.RandomArtifactItemCharacteristics.Blows = true;
                        }
                        item.TypeSpecificValue = item.GetBonusValue(3, level);
                    }
                    break;
            }
            while (Game.RandomLessThan(10 * item.DamageDice * item.DamageDiceSides) == 0)
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
                item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponOfLengRareItem));
                if (Game.DieRoll(6) == 1)
                {
                    item.RandomArtifactItemCharacteristics.DreadCurse = true;
                }
            }
        }
    }
}
