// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class DaggerHopeFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private DaggerHopeFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    protected override string BaseItemFactoryName => nameof(DaggerWeaponItemFactory);

    // Hope shoots a frost bolt
    public void ActivateItem(Item item)
    {
        SaveGame.MsgPrint("Your dagger is covered in frost...");
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FireBolt(SaveGame.SingletonRepository.Projectiles.Get(nameof(Projection.ColdProjectile)), dir, base.SaveGame.DiceRoll(6, 8));
        item.RechargeTimeLeft = base.SaveGame.RandomLessThan(7) + 7;
    }
    public string DescribeActivationEffect => "frost bolt (6d8) every 7+d7 turns";
    public override void ApplyResistances(Item item)
    {
        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, SaveGame.DieRoll(22) + 16);
    }

    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Dagger 'Hope'";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool BrandCold => true;
    public override int Cost => 11000;
    public override int Dd => 1;
    public override int Ds => 4;
    public override string FriendlyName => "'Hope'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 3;
    public override int Pval => 0;
    public override int Rarity => 10;
    public override bool ResCold => true;
    public override bool ShowMods => true;
    public override int ToA => 0;
    public override int ToD => 6;
    public override int ToH => 4;
    public override int Weight => 12;
}
