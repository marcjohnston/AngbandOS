namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class RingOfElementalPowerFireFixedArtifact : FixedArtifact, IActivatible
{
    private readonly ItemFactory _baseItemCategory;
    private RingOfElementalPowerFireFixedArtifact(SaveGame saveGame) : base(saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemFactories.Get<RingNarya>();
    }

    // Ring of Elemental Fire casts a fireball
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("The ring glows deep red...");
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.FireBall(new FireProjectile(saveGame), dir, 120, 3);
        item.RechargeTimeLeft = Program.Rng.RandomLessThan(225) + 225;
    }
    public string DescribeActivationEffect() => "large fire ball (120) every 225+d225 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override char Character => '=';
    public override string Name => "The Ring of Elemental Power (Fire)";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Cha => true;
    public override bool Con => true;
    public override int Cost => 100000;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 1;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Elemental Power (Fire)";
    public override bool HasOwnType => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImFire => true;
    public override bool InstaArt => true;
    public override bool Int => true;
    public override int Level => 70;
    public override int Pval => 1;
    public override int Rarity => 30;
    public override bool Regen => true;
    public override bool SeeInvis => true;
    public override bool SlowDigest => true;
    public override bool Speed => true;
    public override bool Str => true;
    public override bool SustDex => true;
    public override bool SustStr => true;
    public override int ToA => 0;
    public override int ToD => 10;
    public override int ToH => 10;
    public override int Weight => 2;
    public override bool Wis => true;
}
