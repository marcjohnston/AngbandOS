namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class PowerDragonScaleMailBladeturnerFixedArtifact : BaseFixedArtifact, IActivatible
{
    private readonly ItemClass _baseItemCategory;
    private PowerDragonScaleMailBladeturnerFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<DragArmorPowerDragonScaleMail>();
    }

    // Bladeturner heals you and gives you timed resistances
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.MsgPrint("You breathe the elements.");
        saveGame.FireBall(new ProjectMissile(saveGame), dir, 300, 4);
        saveGame.MsgPrint("Your armor glows many colors...");
        saveGame.Player.SetTimedFear(0);
        saveGame.Player.SetTimedSuperheroism(saveGame.Player.TimedSuperheroism + Program.Rng.DieRoll(50) + 50);
        saveGame.Player.RestoreHealth(30);
        saveGame.Player.SetTimedBlessing(saveGame.Player.TimedBlessing + Program.Rng.DieRoll(50) + 50);
        saveGame.Player.SetTimedAcidResistance(saveGame.Player.TimedAcidResistance + Program.Rng.DieRoll(50) + 50);
        saveGame.Player.SetTimedLightningResistance(saveGame.Player.TimedLightningResistance + Program.Rng.DieRoll(50) + 50);
        saveGame.Player.SetTimedFireResistance(saveGame.Player.TimedFireResistance + Program.Rng.DieRoll(50) + 50);
        saveGame.Player.SetTimedColdResistance(saveGame.Player.TimedColdResistance + Program.Rng.DieRoll(50) + 50);
        saveGame.Player.SetTimedPoisonResistance(saveGame.Player.TimedPoisonResistance + Program.Rng.DieRoll(50) + 50);
        item.RechargeTimeLeft = 400;
    }
    public string DescribeActivationEffect() => "breathe elements (300), berserk rage, bless, and resistance";
    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '[';
    public override Colour Colour => Colour.Purple;
    public override string Name => "The Power Dragon Scale Mail 'Bladeturner'";
    public override int Ac => 50;
    public override bool Activate => true;
    public override int Cost => 500000;
    public override int Dd => 2;
    public override int Ds => 4;
    public override bool Feather => true;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.DragonScaleBladeturner;
    public override string FriendlyName => "'Bladeturner'";
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 95;
    public override int Pval => 0;
    public override int Rarity => 3;
    public override bool Regen => true;
    public override bool ResAcid => true;
    public override bool ResBlind => true;
    public override bool ResChaos => true;
    public override bool ResCold => true;
    public override bool ResConf => true;
    public override bool ResDark => true;
    public override bool ResDisen => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool ResNether => true;
    public override bool ResNexus => true;
    public override bool ResPois => true;
    public override bool ResShards => true;
    public override bool ResSound => true;
    public override int ToA => 35;
    public override int ToD => 0;
    public override int ToH => -8;
    public override int Weight => 600;
}
