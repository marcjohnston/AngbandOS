namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class ChaosBookItem : BookItem
    {
        public ChaosBookItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override string GetDescription(bool includeCountPrefix)
        {
            string name = SaveGame.Player.BaseCharacterClass.SpellCastingType == CastingType.Divine ? $"{Pluralize("Book", Count)} of Chaos Magic" : $"Chaos {Pluralize("Spellbook", Count)}";
            name = $"{name} {Factory.FriendlyName}";
            return includeCountPrefix ? GetPrefixCount(true, name, Count, IsKnownArtifact) : name;
        }
    }
}