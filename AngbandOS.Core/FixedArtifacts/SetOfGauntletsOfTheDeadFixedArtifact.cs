using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;
using AngbandOS.Projection;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SetOfGauntletsOfTheDeadFixedArtifact : BaseFixedArtifact, IActivatible
{
    // The Dead shoot acid bolts
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your gauntlets are covered in acid...");
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.FireBolt(new ProjectAcid(saveGame), dir, Program.Rng.DiceRoll(5, 8));
        item.RechargeTimeLeft = Program.Rng.RandomLessThan(5) + 5;
    }
    public string DescribeActivationEffect() => "acid bolt (5d8) every 5+d5 turns";
    public override ItemClass BaseItemCategory => new GlovesSetOfGauntlets();

    public override char Character => ']';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "The Set of Gauntlets of the Dead";
    public override int Ac => 2;
    public override bool Activate => true;
    public override int Cost => 12000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.GauntletsOfTheDead;
    public override string FriendlyName => "of the Dead";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 10;
    public override int Pval => 0;
    public override int Rarity => 20;
    public override bool ResAcid => true;
    public override int ToA => 15;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 25;
}