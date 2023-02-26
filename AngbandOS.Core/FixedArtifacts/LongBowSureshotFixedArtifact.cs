namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LongBowSureshotFixedArtifact : FixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    private LongBowSureshotFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<BowLong>();
    }

    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '}';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "The Long Bow 'Sureshot'";
    public override int Ac => 0;
    public override int Cost => 35000;
    public override int Dd => 0;
    public override bool Dex => true;
    public override int Ds => 0;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.BowSureshot;
    public override string FriendlyName => "'Sureshot'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 40;
    public override int Pval => 3;
    public override int Rarity => 20;
    public override bool ResDisen => true;
    public override bool ShowMods => true;
    public override bool Stealth => true;
    public override int ToA => 0;
    public override int ToD => 22;
    public override int ToH => 20;
    public override int Weight => 40;
    public override bool XtraShots => true;
}
