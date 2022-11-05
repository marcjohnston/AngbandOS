using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;

namespace AngbandOS.Core;

[Serializable]
internal class TheShortSwordOfMerlinFixedArtifact : Base2FixedArtifact
{
    public override BaseItemCategory BaseItemCategory => new SwordShortSword();

    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "The Short Sword of Merlin";
    public override int Ac => 0;
    public override bool Blows => true;
    public override int Cost => 35000;
    public override int Dd => 1;
    public override int Ds => 7;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.ShortSwordOfMerlin;
    public override string FriendlyName => "of Merlin";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override int Pval => 2;
    public override int Rarity => 8;
    public override bool Regen => true;
    public override bool ResDisen => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlowDigest => true;
    public override int ToA => 0;
    public override int ToD => 7;
    public override int ToH => 3;
    public override int Weight => 80;
}
