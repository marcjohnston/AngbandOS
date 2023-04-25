namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TwoHandedFlailThunderfistFixedArtifact : FixedArtifact
{
    private readonly ItemFactory _baseItemCategory;
    private TwoHandedFlailThunderfistFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemFactories.Get<HaftedTwoHandedFlail>();
    }

    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override char Character => '\\';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "The Two-Handed Flail 'Thunderfist'";
    public override int Ac => 0;
    public override bool BrandElec => true;
    public override bool BrandFire => true;
    public override int Cost => 160000;
    public override int Dd => 3;
    public override int Ds => 6;
    public override string FriendlyName => "'Thunderfist'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 45;
    public override bool Lightsource => true;
    public override int Pval => 4;
    public override int Rarity => 38;
    public override bool ResDark => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 18;
    public override int ToH => 5;
    public override int Weight => 300;
}
