// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SpearGungnirFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private SpearGungnirFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    protected override string BaseItemFactoryName => nameof(SpearPolearmWeaponItemFactory);

    // Grungnir shoots a lightning ball
    public void ActivateItem(Item item)
    {
        SaveGame.MsgPrint("Your spear crackles with electricity...");
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(ElecProjectile)), dir, 100, 3);
        item.RechargeTimeLeft = 500;
    }
    public string DescribeActivationEffect() => "lightning ball (100) every 500 turns";

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ForwardSlashSymbol));
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "The Spear 'Gungnir'";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Blessed => true;
    public override bool BrandElec => true;
    public override bool BrandFire => true;
    public override int Cost => 180000;
    public override int Dd => 4;
    public override int Ds => 6;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Gungnir'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override int Level => 15;
    public override bool Lightsource => true;
    public override int Pval => 4;
    public override int Rarity => 45;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool ShowMods => true;
    public override bool SlayGiant => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool SlowDigest => true;
    public override int ToA => 5;
    public override int ToD => 25;
    public override int ToH => 15;
    public override int Weight => 50;
    public override bool Wis => true;
}
