using static AngbandOS.Extensions;

namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class RodItemClass : ItemClass
    {
        public RodItemClass(SaveGame saveGame) : base(saveGame) { }
        public abstract bool RequiresAiming { get; }
        public override bool EasyKnow => true;
        public override bool HasFlavor => true;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Rod;
        public override bool CanAbsorb(Item item, Item other)
        {
            if (item.TypeSpecificValue != other.TypeSpecificValue)
            {
                return false;
            }
            return true;
        }
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string flavour = item.IdentStoreb ? "" : $"{item.SaveGame.RodFlavours[item.ItemSubCategory].Name} ";
            string ofName = item.IsFlavourAware() ? $" of {item.BaseItemCategory.FriendlyName}" : "";
            string name = $"{flavour}{Pluralize("Rod", item.Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override int BaseValue => 90;
        public override Colour Colour => Colour.Turquoise;
        public override string GetVerboseDescription(Item item)
        {
            string s = "";
            if (item.IsKnown() && item.TypeSpecificValue != 0)
            {
                s += $" (charging)";
            }
            s += base.GetVerboseDescription(item);
            return s;
        }

        public abstract void Execute(ZapRodEvent zapRodEvent);
    }
}
