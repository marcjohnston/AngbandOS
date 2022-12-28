using AngbandOS.Core.Interface;
using AngbandOS.Core.ItemCategories;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;
using AngbandOS.Projection;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SetOfLeatherGlovesOfLightFixedArtifact : BaseFixedArtifact, IActivatible
{
    private readonly ItemClass _baseItemCategory;
    private SetOfLeatherGlovesOfLightFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<GlovesSetOfLeatherGloves>();
    }

    // Light shoots magic missiles
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your gloves glow extremely brightly...");
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.FireBolt(new ProjectMissile(saveGame), dir, Program.Rng.DiceRoll(2, 6));
        item.RechargeTimeLeft = 2;
    }
    public string DescribeActivationEffect() => "magic missile (2d6) every 2 turns";
    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => ']';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "The Set of Leather Gloves of Light";
    public override int Ac => 1;
    public override bool Activate => true;
    public override int Cost => 30000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.GlovesOfLight;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Light";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 10;
    public override bool Lightsource => true;
    public override int Pval => 0;
    public override int Rarity => 3;
    public override bool ResLight => true;
    public override bool SustCon => true;
    public override int ToA => 10;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 5;
}
