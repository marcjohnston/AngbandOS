namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class HardLeatherCapOfTheMindcrafterFixedArtifact : FixedArtifact
{
    private readonly ItemFactory _baseItemCategory;
    private HardLeatherCapOfTheMindcrafterFixedArtifact(SaveGame saveGame) : base(saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemFactories.Get<HelmHardLeatherCap>();
    }

    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
    }
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override char Character => ']';
    public override Colour Colour => Colour.Brown;
    public override string Name => "The Hard Leather Cap of the Mindcrafter";
    public override int Ac => 2;
    public override int Cost => 50000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override string FriendlyName => "of the Mindcrafter";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override int Level => 20;
    public override int Pval => 2;
    public override int Rarity => 2;
    public override bool ResBlind => true;
    public override bool Telepathy => true;
    public override int ToA => 10;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 15;
    public override bool Wis => true;
}
