namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class GemstoneShiningTrapezodedronFixedArtifact : BaseFixedArtifact, IActivatible
{
    private readonly ItemClass _baseItemCategory;
    private GemstoneShiningTrapezodedronFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<LightGemstone>();
    }

    // Shining Trapezohedron lights the entire level and recalls us, but drains
    // health to do so
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("The gemstone flashes bright red!");
        saveGame.Level.WizLight();
        saveGame.MsgPrint("The gemstone drains your vitality...");
        saveGame.Player.TakeHit(Program.Rng.DiceRoll(3, 8), "the Gemstone 'Trapezohedron'");
        saveGame.DetectTraps();
        saveGame.DetectDoors();
        saveGame.DetectStairs();
        if (saveGame.GetCheck("Activate recall? "))
        {
            saveGame.Player.ToggleRecall();
        }
        item.RechargeTimeLeft = Program.Rng.RandomLessThan(20) + 20;
    }
    public string DescribeActivationEffect() => "clairvoyance and recall, draining you";
    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '*';
    public override Colour Colour => Colour.Red;
    public override string Name => "The Gemstone 'Shining Trapezodedron'";
    public override int Ac => 0;
    public override bool Activate => true;
    public override int Cost => 150000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.ShiningTrapezohedron;
    public override string FriendlyName => "'Shining Trapezodedron'";
    public override bool HasOwnType => true;
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool InstaArt => true;
    public override bool Int => true;
    public override int Level => 50;
    public override int Pval => 3;
    public override int Rarity => 50;
    public override bool ResChaos => true;
    public override bool SeeInvis => true;
    public override bool Speed => true;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 5;
    public override bool Wis => true;
}
