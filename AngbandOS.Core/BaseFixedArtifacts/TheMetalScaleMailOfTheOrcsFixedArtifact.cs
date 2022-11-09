using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;

namespace AngbandOS.Core;

[Serializable]
internal class TheMetalScaleMailOfTheOrcsFixedArtifact : Base2FixedArtifact
{
    public override ItemClass BaseItemCategory => new HardArmorMetalScaleMail();

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
