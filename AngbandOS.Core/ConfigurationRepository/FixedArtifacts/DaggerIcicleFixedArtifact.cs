// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class DaggerIcicleFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private DaggerIcicleFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Bind()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get(nameof(DaggerWeaponItemFactory));
    }


    // Icicle shoots a cold ball
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your dagger is covered in frost...");
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get(nameof(ColdProjectile)), dir, 48, 2);
        item.RechargeTimeLeft = SaveGame.Rng.RandomLessThan(5) + 5;
    }
    public string DescribeActivationEffect() => "frost ball (48) every 5+d5 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(VerticalBarSymbol));
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Dagger 'Icicle'";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Blows => true;
    public override bool BrandCold => true;
    public override bool BrandPois => true;
    public override int Cost => 50000;
    public override int Dd => 2;
    public override bool Dex => true;
    public override int Ds => 4;
    public override string FriendlyName => "'Icicle'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 10;
    public override int Pval => 2;
    public override int Rarity => 40;
    public override bool Regen => true;
    public override bool ResCold => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlowDigest => true;
    public override bool Speed => true;
    public override int ToA => 0;
    public override int ToD => 9;
    public override int ToH => 6;
    public override int Weight => 12;
}
