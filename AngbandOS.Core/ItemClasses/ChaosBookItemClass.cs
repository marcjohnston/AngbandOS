namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class ChaosBookItemClass : BookItemClass
    {
        public ChaosBookItemClass(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.ChaosBook;
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string name = item.SaveGame.Player.BaseCharacterClass.SpellCastingType == CastingType.Divine ? $"{Pluralize("Book", item.Count)} of Chaos Magic" : $"Chaos {Pluralize("Spellbook", item.Count)}";
            name = $"{name} {item.BaseItemCategory.FriendlyName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override bool HatesFire => true;
        public override Colour Colour => Colour.BrightRed;
        public override BaseRealm? ToRealm => SaveGame.SingletonRepository.Realms.Get<ChaosRealm>();
    }
}
