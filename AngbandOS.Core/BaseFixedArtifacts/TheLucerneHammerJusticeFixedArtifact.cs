using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TheLucerneHammerJusticeFixedArtifact : Base2FixedArtifact
{
    public override ItemClass BaseItemCategory => new HaftedLucerneHammer();

    public override char Character => '\\';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "The Lucerne Hammer 'Justice'";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool BrandCold => true;
    public override int Cost => 30000;
    public override int Dd => 2;
    public override int Ds => 5;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.HammerJustice;
    public override string FriendlyName => "'Justice'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    public override int Level => 20;
    public override bool Lightsource => true;
    public override int Pval => 4;
    public override int Rarity => 15;
    public override bool Regen => true;
    public override bool ResCold => true;
    public override bool ResLight => true;
    public override bool ShowMods => true;
    public override bool SlayOrc => true;
    public override int ToA => 8;
    public override int ToD => 6;
    public override int ToH => 10;
    public override int Weight => 120;
    public override bool Wis => true;
}
