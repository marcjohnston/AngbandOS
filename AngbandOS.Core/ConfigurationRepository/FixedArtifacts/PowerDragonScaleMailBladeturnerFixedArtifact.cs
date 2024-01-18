// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class PowerDragonScaleMailBladeturnerFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private PowerDragonScaleMailBladeturnerFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get(nameof(PowerDragonScaleMailArmorItemFactory));
    }


    // Bladeturner heals you and gives you timed resistances
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.MsgPrint("You breathe the elements.");
        saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get(nameof(MissileProjectile)), dir, 300, 4);
        saveGame.MsgPrint("Your armor glows many colors...");
        saveGame.TimedFear.ResetTimer();
        saveGame.TimedSuperheroism.AddTimer(SaveGame.Rng.DieRoll(50) + 50);
        saveGame.RestoreHealth(30);
        saveGame.TimedBlessing.AddTimer(SaveGame.Rng.DieRoll(50) + 50);
        saveGame.TimedAcidResistance.AddTimer(SaveGame.Rng.DieRoll(50) + 50);
        saveGame.TimedLightningResistance.AddTimer(SaveGame.Rng.DieRoll(50) + 50);
        saveGame.TimedFireResistance.AddTimer(SaveGame.Rng.DieRoll(50) + 50);
        saveGame.TimedColdResistance.AddTimer(SaveGame.Rng.DieRoll(50) + 50);
        saveGame.TimedPoisonResistance.AddTimer(SaveGame.Rng.DieRoll(50) + 50);
        item.RechargeTimeLeft = 400;
    }
    public string DescribeActivationEffect() => "breathe elements (300), berserk rage, bless, and resistance";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(OpenBraceSymbol));
    public override ColourEnum Colour => ColourEnum.Purple;
    public override string Name => "The Power Dragon Scale Mail 'Bladeturner'";
    public override int Ac => 50;
    public override bool Activate => true;
    public override int Cost => 500000;
    public override int Dd => 2;
    public override int Ds => 4;
    public override bool Feather => true;
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
