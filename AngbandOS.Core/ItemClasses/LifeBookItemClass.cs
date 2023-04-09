namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class LifeBookItemClass : BookItemClass
    {
        public LifeBookItemClass(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.LifeBook;
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string name = item.SaveGame.Player.BaseCharacterClass.SpellCastingType == CastingType.Divine ? $"{Pluralize("Book", item.Count)} of Life Magic" : $"Life {Pluralize("Spellbook", item.Count)}";
            name = $"{name} {item.Factory.FriendlyName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override bool HatesFire => true;
        public override Colour Colour => Colour.BrightWhite;
        public override BaseRealm? ToRealm => SaveGame.SingletonRepository.Realms.Get<LifeRealm>();
    }
}
