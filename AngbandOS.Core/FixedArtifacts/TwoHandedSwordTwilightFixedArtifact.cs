namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TwoHandedSwordTwilightFixedArtifact : FixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    private TwoHandedSwordTwilightFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<SwordTwoHandedSword>();
    }

    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "The Two-Handed Sword 'Twilight'";
    public override int Ac => 0;
    public override bool Aggravate => true;
    public override bool BrandFire => true;
    public override int Cost => 0;
    public override bool Cursed => true;
    public override int Dd => 4;
    public override bool DreadCurse => true;
    public override int Ds => 6;
    public override string FriendlyName => "'Twilight'";
    public override bool HeavyCurse => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImFire => true;
    public override int Level => 30;
    public override bool Lightsource => true;
    public override int Pval => 10;
    public override int Rarity => 15;
    public override bool ResDisen => true;
    public override bool ResFear => true;
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override bool Speed => true;
    public override int ToA => -50;
    public override int ToD => -60;
    public override int ToH => -40;
    public override int Weight => 250;
}
