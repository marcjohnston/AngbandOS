using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class PairOfHardLeatherBootsOfIthaquaFixedArtifact : BaseFixedArtifact, IActivatible
{
    // Boots haste you
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("A wind swirls around your boots...");
        if (saveGame.Player.TimedHaste == 0)
        {
            saveGame.Player.SetTimedHaste(Program.Rng.DieRoll(20) + 20);
        }
        else
        {
            saveGame.Player.SetTimedHaste(saveGame.Player.TimedHaste + 5);
        }
        item.RechargeTimeLeft = 200;
    }
    public string DescribeActivationEffect() => "haste self (20+d20 turns) every 200 turns";
    public override ItemClass BaseItemCategory => new BootsHardLeatherBoots();

    public override char Character => ']';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "The Pair of Hard Leather Boots of Ithaqua";
    public override int Ac => 3;
    public override bool Activate => true;
    public override int Cost => 300000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.BootsOfIthaqua;
    public override string FriendlyName => "of Ithaqua";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 40;
    public override int Pval => 15;
    public override int Rarity => 120;
    public override bool ResNexus => true;
    public override bool Speed => true;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 40;
}