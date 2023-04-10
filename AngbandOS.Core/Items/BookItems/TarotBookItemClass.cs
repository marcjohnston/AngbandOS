namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class TarotBookItemClass : BookItemClass
    {
        public TarotBookItemClass(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.TarotBook;
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string name = item.SaveGame.Player.BaseCharacterClass.SpellCastingType == CastingType.Divine ? $"{Pluralize("Book", item.Count)} of Tarot Magic" : $"Tarot {Pluralize("Spellbook", item.Count)}";
            name = $"{name} {item.Factory.FriendlyName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override int PackSort => 3;
        public override bool HatesFire => true;
        public override Colour Colour => Colour.Pink;
        public override BaseRealm? ToRealm => SaveGame.SingletonRepository.Realms.Get<TarotRealm>();
    }
}
