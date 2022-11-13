using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class ThePairOfHardLeatherBootsOfIthaquaFixedArtifact : Base2FixedArtifact
{
    public override ItemClass BaseItemCategory => new BootsHardLeatherBoots();

    public override char Character => ']';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "The Pair of Hard Leather Boots of Ithaqua";
    public override int Ac => 3;
    public override bool Activate => true;
    public override int Cost => 300000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.BootsOfIthaqua;
    public override string FriendlyName => "of Ithaqua";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 40;
    public override int Pval => 15;
    public override int Rarity => 120;
    public override bool ResNexus => true;
    public override bool Speed => true;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 40;
}
