namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class CloakItemClass : ArmourItemClass
    {
        public CloakItemClass(SaveGame saveGame) : base(saveGame) { }
        public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<CloakInventorySlot>();
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Cloak;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightBrown;

        protected override void ApplyRandomGoodRareCharacteristics(Item item)
        {
            WeightedRandom<RareItemTypeEnum> weightedRandom = new WeightedRandom<RareItemTypeEnum>();
            weightedRandom.Add(8, RareItemTypeEnum.CloakOfProtection);
            weightedRandom.Add(8, RareItemTypeEnum.CloakOfStealth);
            weightedRandom.Add(1, RareItemTypeEnum.CloakOfAman);
            weightedRandom.Add(1, RareItemTypeEnum.CloakOfElectricity);
            weightedRandom.Add(1, RareItemTypeEnum.CloakOfImmolation);
            item.RareItemTypeIndex = weightedRandom.Choose();
        }

        protected override void ApplyRandomPoorRareCharacteristics(Item item)
        {
            switch (Program.Rng.DieRoll(3))
            {
                case 1:
                    item.RareItemTypeIndex = RareItemTypeEnum.CloakOfIrritation;
                    break;
                case 2:
                    item.RareItemTypeIndex = RareItemTypeEnum.CloakOfVulnerability;
                    break;
                case 3:
                    item.RareItemTypeIndex = RareItemTypeEnum.CloakOfEnveloping;
                    break;
            }
        }

        public override void ApplyMagic(Item item, int level, int power)
        {
            if (power != 0)
            {
                // Apply the standard armour characteristics.
                base.ApplyMagic(item, level, power);

                if (power > 1)
                {
                    if (Program.Rng.DieRoll(20) == 1)
                    {
                        item.CreateRandart(false);
                    }
                    else
                    {
                        ApplyRandomGoodRareCharacteristics(item);
                    }
                }
                else if (power < -1)
                {
                    ApplyRandomPoorRareCharacteristics(item);
                }
            }
        }

        public override bool CanProvideSheathOfElectricity => true;

        public override bool CanProvideSheathOfFire => true;

        public override bool CanReflectBoltsAndArrows => true;
        public override int PackSort => 22;
    }
}
