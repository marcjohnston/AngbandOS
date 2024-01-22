// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MorningStarFirestarterFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private MorningStarFirestarterFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Bind()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get(nameof(HaftedMorningStar));
    }


    // Firestarter does fire ball
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your morning star rages in fire...");
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get(nameof(FireProjectile)), dir, 72, 3);
        item.RechargeTimeLeft = 100;
    }
    public string DescribeActivationEffect() => "large fire ball (72) every 100 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(BackSlashSymbol));
    public override ColourEnum Colour => ColourEnum.Black;
    public override string Name => "The Morning Star 'Firestarter'";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool BrandFire => true;
    public override int Cost => 35000;
    public override int Dd => 2;
    public override int Ds => 6;
    public override string FriendlyName => "'Firestarter'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override bool Lightsource => true;
    public override int Pval => 0;
    public override int Rarity => 15;
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override int ToA => 2;
    public override int ToD => 7;
    public override int ToH => 5;
    public override int Weight => 150;
}
