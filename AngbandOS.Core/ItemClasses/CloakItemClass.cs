using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class CloakItemClass : ArmourItemClass
    {
        public CloakItemClass(SaveGame saveGame) : base(saveGame) { }
        public override int WieldSlot => InventorySlot.Cloak;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Cloak;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightBrown;

        protected override void ApplyRandomGoodRareCharacteristics(Item item)
        {
            WeightedRandom<Enumerations.RareItemType> weightedRandom = new WeightedRandom<Enumerations.RareItemType>();
            weightedRandom.Add(8, Enumerations.RareItemType.CloakOfProtection);
            weightedRandom.Add(8, Enumerations.RareItemType.CloakOfStealth);
            weightedRandom.Add(1, Enumerations.RareItemType.CloakOfAman);
            weightedRandom.Add(1, Enumerations.RareItemType.CloakOfElectricity);
            weightedRandom.Add(1, Enumerations.RareItemType.CloakOfImmolation);
            item.RareItemTypeIndex = weightedRandom.Choose();
        }

        protected override void ApplyRandomPoorRareCharacteristics(Item item)
        {
            switch (Program.Rng.DieRoll(3))
            {
                case 1:
                    item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfIrritation;
                    break;
                case 2:
                    item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfVulnerability;
                    break;
                case 3:
                    item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfEnveloping;
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
    }
}
