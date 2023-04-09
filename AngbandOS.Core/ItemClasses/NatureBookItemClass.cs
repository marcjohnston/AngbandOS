namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class NatureBookItemClass : BookItemClass
    {
        public NatureBookItemClass(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.NatureBook;
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string name = item.SaveGame.Player.BaseCharacterClass.SpellCastingType == CastingType.Divine ? $"{Pluralize("Book", item.Count)} of Nature Magic" : $"Nature {Pluralize("Spellbook", item.Count)}";
            name = $"{name} {item.BaseItemCategory.FriendlyName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }

        public override bool HatesFire => true;
        public override Colour Colour => Colour.BrightGreen;
        public override BaseRealm? ToRealm => SaveGame.SingletonRepository.Realms.Get<NatureRealm>();
    }
}
