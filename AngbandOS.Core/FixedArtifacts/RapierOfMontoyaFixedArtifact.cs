namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class RapierOfMontoyaFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    private RapierOfMontoyaFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<SwordRapier>();
    }

    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "The Rapier of Montoya";
    public override int Ac => 0;
    public override bool BrandCold => true;
    public override int Cost => 15000;
    public override int Dd => 1;
    public override int Ds => 6;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.RapierOfMontoya;
    public override string FriendlyName => "of Montoya";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 15;
    public override bool Lightsource => true;
    public override int Pval => 0;
    public override int Rarity => 8;
    public override bool ResCold => true;
    public override bool ResLight => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override int ToA => 0;
    public override int ToD => 19;
    public override int ToH => 12;
    public override int Weight => 40;
}
