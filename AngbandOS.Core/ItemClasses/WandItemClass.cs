namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class WandItemClass : ItemClass
    {
        public WandItemClass(SaveGame saveGame) : base(saveGame) { }
        public override bool HasFlavor => true;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Wand;
        public abstract bool ExecuteActivation(SaveGame saveGame, int dir);
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string flavour = item.IdentStoreb ? "" : $"{item.SaveGame.WandFlavours[item.ItemSubCategory].Name} ";
            string ofName = item.IsFlavourAware() ? $" of {item.BaseItemCategory.FriendlyName}" : "";
            string name = $"{flavour}{Pluralize("Wand", item.Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override int BaseValue => 50;
        public override bool HatesElectricity => true;
        public override bool CanAbsorb(Item item, Item other)
        {
            if (!item.IsKnown() || !other.IsKnown())
            {
                return false;
            }
            if (item.TypeSpecificValue != other.TypeSpecificValue)
            {
                return false;
            }
            return true;
        }

        //public override bool IsCharged => true;
        public override Colour Colour => Colour.Chartreuse;
        public override int PercentageBreakageChance => 25;
        public override int? GetBonusRealValue(Item item, int value)
        {
            return value / 20 * item.TypeSpecificValue;
        }

        public override string GetVerboseDescription(Item item)
        {
            string s = "";
            if (item.IsKnown())
            {
                s += $" ({item.TypeSpecificValue} {Pluralize("charge", item.TypeSpecificValue)})";
            }
            s += base.GetVerboseDescription(item);
            return s;
        }
        public override int PackSort => 14;
    }
}
