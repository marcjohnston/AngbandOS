namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class DeathBookItemClass : BookItemClass
    {
        public DeathBookItemClass(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.DeathBook;
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string name = item.SaveGame.Player.BaseCharacterClass.SpellCastingType == CastingType.Divine ? $"{Pluralize("Book", item.Count)} of Death Magic" : $"Death {Pluralize("Spellbook", item.Count)}";
            name = $"{name} {item.Factory.FriendlyName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override bool HatesFire => true;
        public override int PackSort => 4;
        public override Colour Colour => Colour.Black;

        public override BaseRealm? ToRealm => SaveGame.SingletonRepository.Realms.Get<DeathRealm>();
    }
}
