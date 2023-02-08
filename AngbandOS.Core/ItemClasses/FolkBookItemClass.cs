namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class FolkBookItemClass : BookItemClass
    {
        public FolkBookItemClass(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.FolkBook;
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string name = item.SaveGame.Player.BaseCharacterClass.SpellCastingType == CastingType.Divine ? $"{Pluralize("Book", item.Count)} of Folk Magic" : $"Folk {Pluralize("Spellbook", item.Count)}";
            name = $"{name} {item.BaseItemCategory.FriendlyName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override bool HatesFire => true;
        public override Colour Colour => Colour.BrightPurple;
        public override Realm? SpellBookToToRealm => Realm.Folk;
        public override BaseRealm? ToRealm => SaveGame.SingletonRepository.Realms.Get<FolkRealm>();
    }
}
