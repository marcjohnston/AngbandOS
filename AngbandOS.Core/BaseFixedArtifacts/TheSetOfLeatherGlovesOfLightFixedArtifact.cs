using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TheSetOfLeatherGlovesOfLightFixedArtifact : Base2FixedArtifact
{
    public override ItemClass BaseItemCategory => new GlovesSetOfLeatherGloves();

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
