namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class BroadSwordBrightbladeFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    private BroadSwordBrightbladeFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<SwordBroadSword>();
    }

    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        if (Program.Rng.DieRoll(2) == 1)
        {
            IArtifactBias artifactBias = null;
            item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
        }
        else
        {
            item.BonusPowerType = Enumerations.RareItemType.SpecialAbility;
            item.BonusPowerSubType = ActivationPowerManager.GetRandom();
        }
    }
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "The Broad Sword 'Brightblade'";
    public override int Ac => 0;
    public override bool BrandFire => true;
    public override int Cost => 40000;
    public override int Dd => 2;
    public override int Ds => 5;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.SwordBrightblade;
    public override string FriendlyName => "'Brightblade'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override bool Lightsource => true;
    public override int Pval => 1;
    public override int Rarity => 20;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool Search => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlowDigest => true;
    public override int ToA => 0;
    public override int ToD => 15;
    public override int ToH => 10;
    public override int Weight => 150;
}
