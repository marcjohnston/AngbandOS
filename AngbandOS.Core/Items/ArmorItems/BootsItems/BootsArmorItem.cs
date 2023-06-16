namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class BootsArmorItem : ArmourItem
{
    public override int WieldSlot => InventorySlot.Feet;
    public BootsArmorItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }


    protected override void ApplyRandomGoodRareCharacteristics()
    {
        switch (Program.Rng.DieRoll(24))
        {
            case 1:
                RareItemTypeIndex = RareItemTypeEnum.BootsOfSpeed;
                break;
            case 2:
            case 3:
            case 4:
            case 5:
                RareItemTypeIndex = RareItemTypeEnum.BootsOfFreeAction;
                break;
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
                RareItemTypeIndex = RareItemTypeEnum.BootsOfStealth;
                break;
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
            case 21:
            case 22:
            case 23:
            case 24:
                RareItemTypeIndex = RareItemTypeEnum.BootsWinged;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    IArtifactBias artifactBias = null;
                    ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                }
                break;
        }
    }


    /// <summary>
    /// Applies a poor random rare characteristics to boots.
    /// </summary>
    /// <param name="item"></param>
    protected override void ApplyRandomPoorRareCharacteristics()
    {
        switch (Program.Rng.DieRoll(3))
        {
            case 1:
                RareItemTypeIndex = RareItemTypeEnum.BootsOfNoise;
                break;
            case 2:
                RareItemTypeIndex = RareItemTypeEnum.BootsOfSlowness;
                break;
            case 3:
                RareItemTypeIndex = RareItemTypeEnum.BootsOfAnnoyance;
                break;
        }
    }

    /// <summary>
    /// Applies standard magic to boots.
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