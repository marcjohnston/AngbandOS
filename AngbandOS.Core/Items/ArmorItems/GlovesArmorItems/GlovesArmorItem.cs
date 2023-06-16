// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class GlovesArmorItem : ArmourItem
{
    public GlovesArmorItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    public override int WieldSlot => InventorySlot.Hands;

    /// <summary>
    /// Applies a good random rare characteristics to gloves.
    /// </summary>
    /// <param name="item"></param>
    protected override void ApplyRandomGoodRareCharacteristics()
    {
        switch (Program.Rng.DieRoll(10))
        {
            case 1:
            case 2:
            case 3:
            case 4:
                RareItemTypeIndex = RareItemTypeEnum.GlovesOfFreeAction;
                break;
            case 5:
            case 6:
            case 7:
                RareItemTypeIndex = RareItemTypeEnum.GlovesOfSlaying;
                break;
            case 8:
            case 9:
                RareItemTypeIndex = RareItemTypeEnum.GlovesOfAgility;
                break;
            case 10:
                IArtifactBias artifactBias = null;
                RareItemTypeIndex = RareItemTypeEnum.GlovesOfPower;
                ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                break;
        }
    }

    /// <summary>
    /// Applies a poor random rare characteristics to gloves.
    /// </summary>
    /// <param name="item"></param>
    protected override void ApplyRandomPoorRareCharacteristics()
    {
        switch (Program.Rng.DieRoll(2))
        {
            case 1:
                {
                    RareItemTypeIndex = RareItemTypeEnum.GlovesOfClumsiness;
                    break;
                }
            default:
                {
                    RareItemTypeIndex = RareItemTypeEnum.GlovesOfWeakness;
                    break;
                }
        }
    }

    /// <summary>
    /// Applies standard magic to gloves.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        if (power != 0)
        {
            // Apply the standard armour characteristics.
            base.ApplyMagic(level, power, null);

            if (power > 1)
            {
                if (Program.Rng.DieRoll(20) == 1)
                {
                    CreateRandart(false);
                }
                else
                {
                    ApplyRandomGoodRareCharacteristics();
                }
            }
            else if (power < -1)
            {
                ApplyRandomPoorRareCharacteristics();
            }
        }
    }
}