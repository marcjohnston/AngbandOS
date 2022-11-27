using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SteelHelmOfHammerhandFixedArtifact : BaseFixedArtifact
{
    public override ItemClass BaseItemCategory => new HelmSteelHelm();

    public override char Character => ']';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "The Steel Helm of Hammerhand";
    public override int Ac => 6;
    public override bool Con => true;
    public override int Cost => 45000;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 3;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.HelmOfHammerhand;
    public override string FriendlyName => "of Hammerhand";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override int Pval => 3;
    public override int Rarity => 2;
    public override bool ResAcid => true;
    public override bool ResNexus => true;
    public override bool Str => true;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 60;
}
