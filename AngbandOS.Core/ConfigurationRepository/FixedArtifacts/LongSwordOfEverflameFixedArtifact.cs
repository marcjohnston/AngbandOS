// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LongSwordOfEverflameFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private LongSwordOfEverflameFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    protected override string BaseItemFactoryName => nameof(LongSwordWeaponItemFactory);

    // Everflame shoots a fire ball
    public void ActivateItem(Item item)
    {
        SaveGame.MsgPrint("Your sword glows an intense red...");
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(FireProjectile)), dir, 72, 2);
        item.RechargeTimeLeft = 400;
    }
    public string DescribeActivationEffect => "fire ball (72) every 400 turns";
    public override void ApplyResistances(Item item)
    {
        if (SaveGame.DieRoll(2) == 1)
        {
            IArtifactBias artifactBias = null;
            item.ApplyRandomResistance(ref artifactBias, SaveGame.DieRoll(22) + 16);
        }
        else
        {
            item.BonusPowerType = RareItemTypeEnum.SpecialAbility;
            item.BonusPowerSubType= SaveGame.SingletonRepository.Activations.ToWeightedRandom().Choose();
        }
    }

    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Long Sword of Everflame";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool BrandFire => true;
    public override int Cost => 80000;
    public override int Dd => 2;
    public override int Ds => 5;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Everflame";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override bool Lightsource => true;
    public override int Pval => 4;
    public override int Rarity => 40;
    public override bool ResFire => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool Str => true;
    public override bool SustDex => true;
    public override int ToA => 5;
    public override int ToD => 15;
    public override int ToH => 10;
    public override int Weight => 130;
}
