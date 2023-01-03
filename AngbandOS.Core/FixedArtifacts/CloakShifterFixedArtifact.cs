namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class CloakShifterFixedArtifact : BaseFixedArtifact, IActivatible
{
    private readonly ItemClass _baseItemCategory;
    private CloakShifterFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<Cloak>();
    }

    // Shifter teleports you
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your cloak twists space around you...");
        saveGame.TeleportPlayer(100);
        item.RechargeTimeLeft = 45;
    }
    public string DescribeActivationEffect() => "teleport every 45 turns";
    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '(';
    public override Colour Colour => Colour.Green;
    public override string Name => "The Cloak 'Shifter'";
    public override int Ac => 1;
    public override bool Activate => true;
    public override int Cost => 11000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.CloakShifter;
    public override string FriendlyName => "'Shifter'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 3;
    public override int Pval => 3;
    public override int Rarity => 10;
    public override bool ResAcid => true;
    public override bool Stealth => true;
    public override int ToA => 15;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 10;
}
