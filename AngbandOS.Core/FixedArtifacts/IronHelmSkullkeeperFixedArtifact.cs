namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class IronHelmSkullkeeperFixedArtifact : FixedArtifact, IActivatible
{
    private readonly ItemClass _baseItemCategory;
    private IronHelmSkullkeeperFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<HelmIronHelm>();
    }

    // Skull Keeper detects everything
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your helm glows bright white...");
        saveGame.MsgPrint("An image forms in your mind...");
        saveGame.DetectAll();
        item.RechargeTimeLeft = Program.Rng.RandomLessThan(55) + 55;
    }
    public string DescribeActivationEffect() => "detection every 55+d55 turns";
    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => ']';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Iron Helm 'Skullkeeper'";
    public override int Ac => 5;
    public override bool Activate => true;
    public override int Cost => 100000;
    public override int Dd => 1;
    public override int Ds => 3;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.HelmSkullkeeper;
    public override string FriendlyName => "'Skullkeeper'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override int Level => 20;
    public override int Pval => 2;
    public override int Rarity => 5;
    public override bool ResBlind => true;
    public override bool Search => true;
    public override bool SeeInvis => true;
    public override int ToA => 10;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 75;
    public override bool Wis => true;
}
