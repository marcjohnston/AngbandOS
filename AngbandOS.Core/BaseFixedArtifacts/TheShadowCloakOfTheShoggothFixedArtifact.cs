using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;

namespace AngbandOS.Core;

[Serializable]
internal class TheShadowCloakOfTheShoggothFixedArtifact : Base2FixedArtifact
{
    public override BaseItemCategory BaseItemCategory => new CloakShadow();

    public override char Character => '(';
    public override Colour Colour => Colour.Black;
    public override string Name => "The Shadow Cloak of the Shoggoth";
    public override int Ac => 6;
    public override int Cost => 35000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.ShadowCloakOfTheShoggoth;
    public override bool FreeAct => true;
    public override string FriendlyName => "of the Shoggoth";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImAcid => true;
    public override int Level => 40;
    public override int Pval => 4;
    public override int Rarity => 40;
    public override bool SeeInvis => true;
    public override bool Stealth => true;
    public override int ToA => 12;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 5;
}
