using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class PairOfSoftLeatherBootsOfDancingFixedArtifact : BaseFixedArtifact, IActivatible
{
    // Dancing heal poison and fear
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your boots glow deep blue...");
        saveGame.Player.SetTimedFear(0);
        saveGame.Player.SetTimedPoison(0);
        item.RechargeTimeLeft = 5;
    }
    public string DescribeActivationEffect() => "remove fear and cure poison every 5 turns";
    public override ItemClass BaseItemCategory => new BootsSoftLeatherBoots();

    public override char Character => ']';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "The Pair of Soft Leather Boots of Dancing";
    public override int Ac => 2;
    public override bool Activate => true;
    public override bool Cha => true;
    public override int Cost => 40000;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 1;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.BootsOfDancing;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Dancing";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 10;
    public override int Pval => 5;
    public override int Rarity => 25;
    public override bool ResChaos => true;
    public override bool ResNether => true;
    public override bool SustCha => true;
    public override bool SustCon => true;
    public override int ToA => 15;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 20;
}