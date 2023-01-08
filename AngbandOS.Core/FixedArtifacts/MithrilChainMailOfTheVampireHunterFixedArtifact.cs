namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MithrilChainMailOfTheVampireHunterFixedArtifact : BaseFixedArtifact, IActivatible
{
    private readonly ItemClass _baseItemCategory;
    private MithrilChainMailOfTheVampireHunterFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<HardArmorMithrilChainMail>();
    }

    // Vampire Hunter cures most ailments
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("A heavenly choir sings...");
        saveGame.Player.TimedPoison.SetTimer(0);
        saveGame.Player.TimedBleeding.SetTimer(0);
        saveGame.Player.TimedStun.SetTimer(0);
        saveGame.Player.TimedConfusion.SetTimer(0);
        saveGame.Player.TimedBlindness.SetTimer(0);
        saveGame.Player.TimedHeroism.SetTimer(saveGame.Player.TimedHeroism.TimeRemaining + Program.Rng.DieRoll(25) + 25);
        saveGame.Player.RestoreHealth(777);
        item.RechargeTimeLeft = 300;
    }
    public string DescribeActivationEffect() => "heal (777), curing and heroism every 300 turns";
    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '[';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "The Mithril Chain Mail of the Vampire Hunter";
    public override int Ac => 28;
    public override bool Activate => true;
    public override int Cost => 135000;
    public override int Dd => 1;
    public override int Ds => 4;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.ArmourOfTheVampireHunter;
    public override string FriendlyName => "of the Vampire Hunter";
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override int Level => 40;
    public override int Pval => 4;
    public override int Rarity => 3;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResDark => true;
    public override bool ResElec => true;
    public override bool ResFear => true;
    public override bool ResFire => true;
    public override bool ResNether => true;
    public override bool ResPois => true;
    public override bool SeeInvis => true;
    public override bool Stealth => true;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => -1;
    public override int Weight => 150;
    public override bool Wis => true;
}
