// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SetOfGauntletsWhiteSparkFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private SetOfGauntletsWhiteSparkFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    protected override string BaseItemFactoryName => nameof(GauntletGlovesArmorItemFactory);

    // White Spark shoot lightning bolts
    public void ActivateItem(Item item)
    {
        SaveGame.MsgPrint("Your gauntlets are covered in sparks...");
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FireBolt(SaveGame.SingletonRepository.Projectiles.Get(nameof(Projection.ElecProjectile)), dir, base.SaveGame.Rng.DiceRoll(4, 8));
        item.RechargeTimeLeft = base.SaveGame.Rng.RandomLessThan(6) + 6;
    }
    public string DescribeActivationEffect => "lightning bolt (4d8) every 6+d6 turns";

    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "The Set of Gauntlets 'White Spark'";
    public override int Ac => 2;
    public override bool Activate => true;
    public override int Cost => 11000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "'White Spark'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 10;
    public override int Pval => 0;
    public override int Rarity => 20;
    public override bool ResElec => true;
    public override int ToA => 15;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 25;
}
