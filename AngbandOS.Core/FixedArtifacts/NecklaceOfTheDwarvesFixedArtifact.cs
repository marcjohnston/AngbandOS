using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class NecklaceOfTheDwarvesFixedArtifact : BaseFixedArtifact
{
    public override ItemClass BaseItemCategory => new AmuletNecklace();

    public override char Character => '"';
    public override string Name => "The Necklace of the Dwarves";
    public override int Ac => 0;
    public override bool Con => true;
    public override int Cost => 75000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.NecklaceOfTheDwarves;
    public override bool FreeAct => true;
    public override string FriendlyName => "of the Dwarves";
    public override bool HasOwnType => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    public override bool InstaArt => true;
    public override int Level => 70;
    public override bool Lightsource => true;
    public override int Pval => 3;
    public override int Rarity => 50;
    public override bool Regen => true;
    public override bool SeeInvis => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 3;
}