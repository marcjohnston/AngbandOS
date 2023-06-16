namespace AngbandOS.Core.Items;

[Serializable]
internal class PowerRingItem : RingItem
{
    public PowerRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PowerRingItemFactory>()) { }
    public override string GetDescription(bool includeCountPrefix)
    {
        if (FixedArtifact != null && IsFlavourAware())
        {
            return base.GetDescription(includeCountPrefix);
        }
        string flavour = IdentStoreb ? "" : $"{FlavourFactory.Flavour.Name} ";
        if (!IsFlavourAware())
        {
            flavour = "Plain Gold ";
        }
        string ofName = IsFlavourAware() ? $" of {Factory.FriendlyName}" : "";
        string name = $"{flavour}{Pluralize("Ring", Count)}{ofName}";
        return includeCountPrefix ? GetPrefixCount(true, name, Count, IsKnownArtifact) : name;
    }
}