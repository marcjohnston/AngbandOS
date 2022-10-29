using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class TheTridentOfWrathFixedArtifact : Base2FixedArtifact
{
    public override char Character => '/';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "The Trident of Wrath";
    public override int Ac => 0;
    public override bool Blessed => true;
    public override bool Chaotic => true;
    public override int Cost => 90000;
    public override int Dd => 3;
    public override bool Dex => true;
    public override int Ds => 8;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.TridentOfWrath;
    public override string FriendlyName => "of Wrath";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 15;
    public override int Pval => 2;
    public override int Rarity => 35;
    public override bool ResDark => true;
    public override bool ResLight => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayUndead => true;
    public override bool Str => true;
    public override int Sval => 5;
    public override int ToA => 0;
    public override int ToD => 18;
    public override int ToH => 16;
    public override ItemCategory Tval => ItemCategory.Polearm;
    public override int Weight => 300;
}
