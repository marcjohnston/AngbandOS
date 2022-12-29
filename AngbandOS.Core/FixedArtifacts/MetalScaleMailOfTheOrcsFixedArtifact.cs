using AngbandOS.ArtifactBiases;
using AngbandOS.Core.ItemCategories;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MetalScaleMailOfTheOrcsFixedArtifact : BaseFixedArtifact, IActivatible
{
    private readonly ItemClass _baseItemCategory;
    private MetalScaleMailOfTheOrcsFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<HardArmorMetalScaleMail>();
    }

    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
    }

    // Orc does Carnage
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your armor glows deep blue...");
        saveGame.Carnage(true);
        item.RechargeTimeLeft = 500;
    }
    public string DescribeActivationEffect() => "carnage every 500 turns";

    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '[';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Metal Scale Mail of the Orcs";
    public override int Ac => 15;
    public override bool Activate => true;
    public override bool Cha => true;
    public override int Cost => 150000;
    public override int Dd => 2;
    public override int Ds => 4;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.ArmourOfTheOrcs;
    public override string FriendlyName => "of the Orcs";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 40;
    public override int Pval => 4;
    public override int Rarity => 3;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResDark => true;
    public override bool ResDisen => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool Str => true;
    public override int ToA => 40;
    public override int ToD => 0;
    public override int ToH => -2;
    public override int Weight => 250;
}
