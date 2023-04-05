namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LargeLeatherShieldRawhideFixedArtifact : FixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    private LargeLeatherShieldRawhideFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<ShieldLargeLeatherShield>();
    }

    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
    }
    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => ')';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "The Large Leather Shield 'Rawhide'";
    public override int Ac => 4;
    public override int Cost => 12000;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "'Rawhide'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 30;
    public override int Pval => 0;
    public override int Rarity => 3;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResDark => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 60;
}
