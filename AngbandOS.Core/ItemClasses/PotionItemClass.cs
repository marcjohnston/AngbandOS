namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class PotionItemClass : ItemClass
    {
        public PotionItemClass(SaveGame saveGame) : base(saveGame) { }
        public override bool EasyKnow => true;
        /// <summary>
        /// Have a potion affect the player.  Activates the potion effect.
        /// </summary>
        /// <returns> True, if drinking the potion identified it; false, to keep the potion as unidentified.</returns>
        public abstract bool Quaff(SaveGame saveGame);

        public static bool IsPotion(ItemClass itemClass)
        {
            return typeof(PotionItemClass).IsAssignableFrom(itemClass.GetType());
        }
        public override bool HasFlavor => true;
        /// <summary>
        /// Perform a smash effect for the potion.
        /// </summary>
        /// <param name="saveGame"></param>
        /// <param name="who"></param>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns>Returns whether or not the action causes pets to become angry and turn against their owner.  Returns false, by default.</returns>
        public virtual bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            return false;
        }

        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Potion;
        public override bool CanAbsorb(Item item, Item other)
        {
            return true;
        }
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string flavour = item.IdentStoreb ? "" : $"{item.SaveGame.SingletonRepository.PotionFlavours[item.ItemSubCategory].Name} ";
            string ofName = item.IsFlavourAware() ? $" of {item.BaseItemCategory.FriendlyName}" : "";
            string name = $"{flavour}{Pluralize("Potion", item.Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override int BaseValue => 20;
        public override bool HatesCold => true;
        public override Colour Colour => Colour.Blue;
        public override int PercentageBreakageChance => 100;

        public override int GetAdditionalMassProduceCount(Item item)
        {
            int cost = item.Value();
            if (cost <= 60)
            {
                return MassRoll(3, 5);
            }
            if (cost <= 240)
            {
                return MassRoll(1, 5);
            }
            return 0;
        }
        public override int PackSort => 11;
    }
}
