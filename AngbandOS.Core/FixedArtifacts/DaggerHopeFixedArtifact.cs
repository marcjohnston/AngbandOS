namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class DaggerHopeFixedArtifact : FixedArtifact, IActivatible
{
    private readonly ItemFactory _baseItemCategory;
    private DaggerHopeFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<SwordDagger>();
    }

    // Hope shoots a frost bolt
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your dagger is covered in frost...");
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.FireBolt(new ColdProjectile(saveGame), dir, Program.Rng.DiceRoll(6, 8));
        item.RechargeTimeLeft = Program.Rng.RandomLessThan(7) + 7;
    }
    public string DescribeActivationEffect() => "frost bolt (6d8) every 7+d7 turns";
    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
    }
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "The Dagger 'Hope'";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool BrandCold => true;
    public override int Cost => 11000;
    public override int Dd => 1;
    public override int Ds => 4;
    public override string FriendlyName => "'Hope'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 3;
    public override int Pval => 0;
    public override int Rarity => 10;
    public override bool ResCold => true;
    public override bool ShowMods => true;
    public override int ToA => 0;
    public override int ToD => 6;
    public override int ToH => 4;
    public override int Weight => 12;
}
