using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;

namespace AngbandOS.Core;

[Serializable]
internal class TheHalberdArmourbaneFixedArtifact : Base2FixedArtifact
{
    public override BaseItemCategory BaseItemCategory => new PolearmHalberd();

    public override char Character => '/';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Halberd 'Armourbane'";
    public override int Ac => 0;
    public override bool BrandFire => true;
    public override bool Cha => true;
    public override int Cost => 22000;
    public override int Dd => 3;
    public override int Ds => 5;
    public override bool Feather => true;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.HalberdArmourbane;
    public override string FriendlyName => "'Armourbane'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override bool Lightsource => true;
    public override int Pval => 3;
    public override int Rarity => 8;
    public override bool ResFire => true;
    public override bool ResSound => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayGiant => true;
    public override bool SlayUndead => true;
    public override int ToA => 0;
    public override int ToD => 9;
    public override int ToH => 6;
    public override int Weight => 190;
}
