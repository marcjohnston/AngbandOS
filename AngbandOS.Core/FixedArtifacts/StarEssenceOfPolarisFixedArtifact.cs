using AngbandOS.Core.Interface;
using AngbandOS.Core.ItemCategories;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class StarEssenceOfPolarisFixedArtifact : BaseFixedArtifact, IActivatible
{
    // Star Essence of Polaris lights the area
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("The essence wells with clear light...");
        saveGame.LightArea(Program.Rng.DiceRoll(2, 15), 3);
        item.RechargeTimeLeft = Program.Rng.RandomLessThan(10) + 10;
    }

    public string DescribeActivationEffect() => "illumination every 10+d10 turns";
    public override ItemClass BaseItemCategory => new LightStarEssenceGaladriel();

    public override char Character => '*';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "The Star Essence of Polaris";
    public override int Ac => 0;
    public override bool Activate => true;
    public override int Cost => 10000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.StarEssenceOfPolaris;
    public override string FriendlyName => "of Polaris";
    public override bool HasOwnType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool InstaArt => true;
    public override int Level => 1;
    public override int Pval => 1;
    public override int Rarity => 1;
    public override bool Search => true;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 10;
}
