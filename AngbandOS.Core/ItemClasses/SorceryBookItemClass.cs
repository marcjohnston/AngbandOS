namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class SorceryBookItemClass : BookItemClass
    {
        public SorceryBookItemClass(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.SorceryBook;
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string name = item.SaveGame.Player.BaseCharacterClass.SpellCastingType == CastingType.Divine ? $"{Pluralize("Book", item.Count)} of Sorcery" : $"Sorcery {Pluralize("Spellbook", item.Count)}";
            name = $"{name} {item.BaseItemCategory.FriendlyName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override bool HatesFire => true;
        public override Colour Colour => Colour.BrightBlue;
        public override Realm? SpellBookToToRealm => Realm.Sorcery;
        public override BaseRealm? ToRealm => SaveGame.SingletonRepository.Realms.Get<SorceryRealm>();
        public override int PackSort => 7;
    }
}
