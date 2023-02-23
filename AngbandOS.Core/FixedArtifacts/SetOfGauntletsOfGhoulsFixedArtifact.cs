namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SetOfGauntletsOfGhoulsFixedArtifact : BaseFixedArtifact, IActivatible
{
    private readonly ItemClass _baseItemCategory;
    private SetOfGauntletsOfGhoulsFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<GlovesSetOfGauntlets>();
    }

    // Ghouls shoot cold bolts
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your gauntlets are covered in frost...");
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.FireBolt(new ColdProjectile(saveGame), dir, Program.Rng.DiceRoll(6, 8));
        item.RechargeTimeLeft = Program.Rng.RandomLessThan(7) + 7;
    }
    public string DescribeActivationEffect() => "frost bolt (6d8) every 7+d7 turns";
    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => ']';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "The Set of Gauntlets of Ghouls";
    public override int Ac => 2;
    public override bool Activate => true;
    public override bool Con => true;
    public override int Cost => 33000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.GauntletsOfGhouls;
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
