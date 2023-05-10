namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class CloakArmorItem : ArmourItem
    {
        public override int WieldSlot => InventorySlot.Cloak;
        public CloakArmorItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }

        protected override void ApplyRandomGoodRareCharacteristics()
        {
            WeightedRandom<RareItemTypeEnum> weightedRandom = new WeightedRandom<RareItemTypeEnum>();
            weightedRandom.Add(8, RareItemTypeEnum.CloakOfProtection);
            weightedRandom.Add(8, RareItemTypeEnum.CloakOfStealth);
            weightedRandom.Add(1, RareItemTypeEnum.CloakOfAman);
            weightedRandom.Add(1, RareItemTypeEnum.CloakOfElectricity);
            weightedRandom.Add(1, RareItemTypeEnum.CloakOfImmolation);
            RareItemTypeIndex = weightedRandom.Choose();
        }


        protected override void ApplyRandomPoorRareCharacteristics()
        {
            switch (Program.Rng.DieRoll(3))
            {
                case 1:
                    RareItemTypeIndex = RareItemTypeEnum.CloakOfIrritation;
                    break;
                case 2:
                    RareItemTypeIndex = RareItemTypeEnum.CloakOfVulnerability;
                    break;
                case 3:
                    RareItemTypeIndex = RareItemTypeEnum.CloakOfEnveloping;
                    break;
            }
        }

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
}