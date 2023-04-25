namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MultiHuedDragonScaleMailRazorbackFixedArtifact : FixedArtifact, IActivatible
{
    private readonly ItemFactory _baseItemCategory;
    private MultiHuedDragonScaleMailRazorbackFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemFactories.Get<MultiHuedDragonScaleMailArmorItemFactory>();
    }

    // Razorback gives you a point-blank lightning ball
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your armor is surrounded by lightning...");
        for (int i = 0; i < 8; i++)
        {
            saveGame.FireBall(new ElecProjectile(saveGame), saveGame.Level.OrderedDirection[i], 150, 3);
        }
        item.RechargeTimeLeft = 1000;
    }

    public string DescribeActivationEffect() => "star ball (150) every 1000 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override char Character => '[';
    public override Colour Colour => Colour.Purple;
    public override string Name => "The Multi-Hued Dragon Scale Mail 'Razorback'";
    public override int Ac => 30;
    public override bool Activate => true;
    public override bool Aggravate => true;
    public override int Cost => 400000;
    public override int Dd => 2;
    public override int Ds => 4;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Razorback'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImElec => true;
    public override int Level => 90;
    public override bool Lightsource => true;
    public override int Pval => 0;
    public override int Rarity => 9;
    public override bool ResCold => true;
    public override bool ResDark => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool ResPois => true;
    public override bool SeeInvis => true;
    public override int ToA => 25;
    public override int ToD => 0;
    public override int ToH => -4;
    public override int Weight => 500;
}
