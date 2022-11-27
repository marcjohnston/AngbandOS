using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;
using AngbandOS.Projection;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class DaggerOfThothFixedArtifact : BaseFixedArtifact, IActivatible
{
    // Thoth shoots a poison ball
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your dagger throbs deep green...");
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.FireBall(new ProjectPois(saveGame), dir, 12, 3);
        item.RechargeTimeLeft = Program.Rng.RandomLessThan(4) + 4;
    }
    public string DescribeActivationEffect() => "stinking cloud (12) every 4+d4 turns";
    public override ItemClass BaseItemCategory => new SwordDagger();

    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "The Dagger of Thoth";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool BrandPois => true;
    public override int Cost => 35000;
    public override int Dd => 2;
    public override int Ds => 4;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.DaggerOfThoth;
    public override string FriendlyName => "of Thoth";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 5;
    public override int Pval => 0;
    public override int Rarity => 40;
    public override bool ResDisen => true;
    public override bool ResPois => true;
    public override bool ShowMods => true;
    public override bool SlayOrc => true;
    public override int ToA => 0;
    public override int ToD => 3;
    public override int ToH => 4;
    public override int Weight => 12;
}
