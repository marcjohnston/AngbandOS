namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LightCrossbowOfDeathFixedArtifact : BaseFixedArtifact, IActivatible
{
    private readonly ItemClass _baseItemCategory;
    private LightCrossbowOfDeathFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<BowLightCrossbow>();
    }

    // Death brands your bolts
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your crossbow glows deep red...");
        saveGame.BrandBolts();
        item.RechargeTimeLeft = 999;
    }
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
    public string DescribeActivationEffect() => "fire branding of bolts every 999 turns";
    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '}';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Light Crossbow of Death";
    public override int Ac => 0;
    public override bool Activate => true;
    public override int Cost => 50000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.CrossbowOfDeath;
    public override string FriendlyName => "of Death";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 50;
    public override int Pval => 10;
    public override int Rarity => 25;
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override bool Speed => true;
    public override int ToA => 0;
    public override int ToD => 14;
    public override int ToH => 10;
    public override int Weight => 110;
    public override bool XtraMight => true;
}
