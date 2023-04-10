namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class ShieldArmorItem : ArmourItem
    {
        public override int WieldSlot => InventorySlot.Arm;
        public ShieldArmorItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 23;


        /// <summary>
        /// Applies a good random rare characteristics to a shield.
        /// </summary>
        protected override void ApplyRandomGoodRareCharacteristics()
        {
            switch (Program.Rng.DieRoll(23))
            {
                case 1:
                case 11:
                    RareItemTypeIndex = RareItemTypeEnum.ShieldOfResistAcid;
                    break;
                case 2:
                case 3:
                case 4:
                case 12:
                case 13:
                case 14:
                    RareItemTypeIndex = RareItemTypeEnum.ShieldOfResistLightning;
                    break;
                case 5:
                case 6:
                case 15:
                case 16:
                    RareItemTypeIndex = RareItemTypeEnum.ShieldOfResistFire;
                    break;
                case 7:
                case 8:
                case 9:
                case 17:
                case 18:
                case 19:
                    RareItemTypeIndex = RareItemTypeEnum.ShieldOfResistCold;
                    break;
                case 10:
                case 20:
                    IArtifactBias artifactBias = null;
                    ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(34) + 4);
                    if (Program.Rng.DieRoll(4) == 1)
                    {
                        RandartItemCharacteristics.ResPois = true;
                    }
                    RareItemTypeIndex = RareItemTypeEnum.ShieldOfResistance;
                    break;
                case 21:
                case 22:
                    RareItemTypeIndex = RareItemTypeEnum.ShieldOfReflection;
                    break;
                case 23:
                    CreateRandart(false);
                    break;
            }
        }

        /// <summary>
        /// Applies standard magic to shields.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="power"></param>
        public override void ApplyMagic(int level, int power)
        {
            if (power != 0)
            {
                // Apply the standard armour characteristics.
                base.ApplyMagic(level, power);

                if (power > 1)
                {
                    ApplyRandomGoodRareCharacteristics();
                }
            }
        }
    }
}