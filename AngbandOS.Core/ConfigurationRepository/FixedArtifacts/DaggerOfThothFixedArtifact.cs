// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class DaggerOfThothFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private DaggerOfThothFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<SwordDagger>();
    }


    // Thoth shoots a poison ball
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your dagger throbs deep green...");
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get<PoisProjectile>(), dir, 12, 3);
        item.RechargeTimeLeft = SaveGame.Rng.RandomLessThan(4) + 4;
    }
    public string DescribeActivationEffect() => "stinking cloud (12) every 4+d4 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<VerticalBarSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightWhite;
    public override string Name => "The Dagger of Thoth";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool BrandPois => true;
    public override int Cost => 35000;
    public override int Dd => 2;
    public override int Ds => 4;
    public override string FriendlyName => "of Thoth";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 5;
    public override int Pval => 0;
    public override int Rarity => 40;
    public override bool ResDisen => true;
    public override bool ResPois => true;
    public override bool ShowMods => true;
    public override bool SlayOrc => true;
    public override int ToA => 0;
    public override int ToD => 3;
    public override int ToH => 4;
    public override int Weight => 12;
}