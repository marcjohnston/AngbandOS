namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SetOfGauntletsWhiteSparkFixedArtifact : FixedArtifact, IActivatible
{
    private readonly ItemClass _baseItemCategory;
    private SetOfGauntletsWhiteSparkFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<GlovesSetOfGauntlets>();
    }

    // White Spark shoot lightning bolts
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your gauntlets are covered in sparks...");
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.FireBolt(new ElecProjectile(saveGame), dir, Program.Rng.DiceRoll(4, 8));
        item.RechargeTimeLeft = Program.Rng.RandomLessThan(6) + 6;
    }
    public string DescribeActivationEffect() => "lightning bolt (4d8) every 6+d6 turns";
    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => ']';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "The Set of Gauntlets 'White Spark'";
    public override int Ac => 2;
    public override bool Activate => true;
    public override int Cost => 11000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.GauntletsWhiteSpark;
    public override string FriendlyName => "'White Spark'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 10;
    public override int Pval => 0;
    public override int Rarity => 20;
    public override bool ResElec => true;
    public override int ToA => 15;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 25;
}
