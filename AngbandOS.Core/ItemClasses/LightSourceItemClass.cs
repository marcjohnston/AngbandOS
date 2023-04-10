namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class LightSourceItemClass : ItemFactory
    {
        public LightSourceItemClass(SaveGame saveGame) : base(saveGame) { }
        public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<LightsourceInventorySlot>();
        public override bool IsWorthless(Item item) => item.TypeSpecificValue < 0;

        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Light;
        public override bool HatesFire => true;
        public override Colour Colour => Colour.BrightYellow;

        public virtual void Refill(SaveGame saveGame, Item item)
        {
            saveGame.MsgPrint("Your light cannot be refilled.");
        }

        public override int? GetTypeSpecificRealValue(Item item, int value)
        {
            return ComputeTypeSpecificRealValue(item, value);
        }

        public override bool CanAbsorb(Item item, Item other)
        {
            if (!item.IsKnown() || !other.IsKnown())
            {
                return false;
            }
            if (!item.StatsAreSame(other))
            {
                return false;
            }
            return true;
        }
        public override int GetAdditionalMassProduceCount(Item item)
        {
            int cost = item.Value();
            if (cost <= 5)
            {
                return MassRoll(3, 5);
            }
            if (cost <= 20)
            {
                return MassRoll(3, 5);
            }
            return 0;
        }

        public override string GetVerboseDescription(Item item)
        {
            string s = "";
            if (item.ItemSubCategory == LightType.Torch || item.ItemSubCategory == LightType.Lantern)
            {
                s += $" (with {item.TypeSpecificValue} {Pluralize("turn", item.TypeSpecificValue)} of light)";
            }
            s += base.GetVerboseDescription(item);
            return s;
        }

        public override string Identify(Item item)
        {
            if (item.FixedArtifact != null)
            {
                return "It provides light (radius 3) forever.";
            }
            else if (item.ItemSubCategory == LightType.Lantern)
            {
                return "It provides light (radius 2) when fueled.";
            }
            else if (item.ItemSubCategory == LightType.Torch)
            {
                return "It provides light (radius 1) when fueled.";
            }
            else
            {
                return "It provides light (radius 2) forever.";
            }
        }
    }
}
