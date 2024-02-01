// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SetOfGauntletsOfGhoulsFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private SetOfGauntletsOfGhoulsFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    protected override string BaseItemFactoryName => nameof(GauntletGlovesArmorItemFactory);

    // Ghouls shoot cold bolts
    public void ActivateItem(Item item)
    {
        SaveGame.MsgPrint("Your gauntlets are covered in frost...");
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FireBolt(SaveGame.SingletonRepository.Projectiles.Get(nameof(Projection.ColdProjectile)), dir, base.SaveGame.Rng.DiceRoll(6, 8));
        item.RechargeTimeLeft = base.SaveGame.Rng.RandomLessThan(7) + 7;
    }
    public string DescribeActivationEffect() => "frost bolt (6d8) every 7+d7 turns";

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(CloseBraceSymbol));
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "The Set of Gauntlets of Ghouls";
    public override int Ac => 2;
    public override bool Activate => true;
    public override bool Con => true;
    public override int Cost => 33000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "of Ghouls";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 10;
    public override int Pval => 4;
    public override int Rarity => 20;
    public override bool Regen => true;
    public override bool ResCold => true;
    public override bool SustCon => true;
    public override int ToA => 15;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 25;
}
