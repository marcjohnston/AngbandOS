using AngbandOS.Core.ItemCategories;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SetOfGauntletsIronfistFixedArtifact : BaseFixedArtifact, IActivatible
{
    private readonly ItemClass _baseItemCategory;
    private SetOfGauntletsIronfistFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<GlovesSetOfGauntlets>();
    }

    // Iron Fist shoots fire bolts
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your gauntlets are covered in fire...");
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.FireBolt(new ProjectFire(saveGame), dir, Program.Rng.DiceRoll(9, 8));
        item.RechargeTimeLeft = Program.Rng.RandomLessThan(8) + 8;
    }
    public string DescribeActivationEffect() => "fire bolt (9d8) every 8+d8 turns";
    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => ']';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "The Set of Gauntlets 'Ironfist'";
    public override int Ac => 2;
    public override bool Activate => true;
    public override int Cost => 15000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.GauntletIronfist;
    public override string FriendlyName => "'Ironfist'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 10;
    public override int Pval => 0;
    public override int Rarity => 20;
    public override bool ResFire => true;
    public override int ToA => 15;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 25;
}
