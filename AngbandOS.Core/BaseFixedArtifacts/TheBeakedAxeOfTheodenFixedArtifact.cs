using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TheBeakedAxeOfTheodenFixedArtifact : Base2FixedArtifact
{
    public override ItemClass BaseItemCategory => new PolearmBeakedAxe();


    public override char Character => '/';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Beaked Axe of Theoden";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Con => true;
    public override int Cost => 40000;
    public override int Dd => 2;
    public override int Ds => 6;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.AxeOfTheoden;
    public override string FriendlyName => "of Theoden";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override int Pval => 3;
    public override int Rarity => 15;
    public override bool ShowMods => true;
    public override bool SlayDragon => true;
    public override bool SlowDigest => true;
    public override bool Telepathy => true;
    public override int ToA => 0;
    public override int ToD => 10;
    public override int ToH => 8;
    public override int Weight => 180;
    public override bool Wis => true;
}
