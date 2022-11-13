using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TheLochaberAxeOfTheDwarvesFixedArtifact : Base2FixedArtifact
{
    public override ItemClass BaseItemCategory => new PolearmLochaberAxe();

    public override char Character => '/';
    public override Colour Colour => Colour.Black;
    public override string Name => "The Lochaber Axe of the Dwarves";
    public override int Ac => 0;
    public override int Cost => 80000;
    public override int Dd => 3;
    public override int Ds => 8;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.AxeOfTheDwarves;
    public override string FriendlyName => "of the Dwarves";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    public override int Level => 30;
    public override int Pval => 10;
    public override int Rarity => 8;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFear => true;
    public override bool ResFire => true;
    public override bool Search => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayGiant => true;
    public override int ToA => 0;
    public override int ToD => 17;
    public override int ToH => 12;
    public override bool Tunnel => true;
    public override int Weight => 250;
}
