using AngbandOS.Core.Interface;
using AngbandOS.Core.ItemCategories;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class ExecutionersSwordOfNyarlathotepFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    public ExecutionersSwordOfNyarlathotepFixedArtifact(SaveGame saveGame) : base(saveGame)
     {
        _baseItemCategory = new SwordExecutionersSword(SaveGame);
    }

    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '|';
    public override Colour Colour => Colour.Red;
    public override string Name => "The Executioner's Sword of Nyarlathotep";
    public override int Ac => 0;
    public override bool BrandPois => true;
    public override int Cost => 111000;
    public override int Dd => 4;
    public override int Ds => 5;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.SwordOfNyarlathotep;
    public override string FriendlyName => "of Nyarlathotep";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 40;
    public override int Pval => 0;
    public override int Rarity => 15;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayDragon => true;
    public override bool SlayEvil => true;
    public override bool SlayGiant => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool SlayUndead => true;
    public override int ToA => 0;
    public override int ToD => 19;
    public override int ToH => 18;
    public override bool Vorpal => true;
    public override int Weight => 260;
}
