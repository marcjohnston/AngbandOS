using AngbandOS.Core.Interface;
using AngbandOS.Core.ItemCategories;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MorningStarBloodspikeFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    public MorningStarBloodspikeFixedArtifact(SaveGame saveGame) : base(saveGame)
     {
        _baseItemCategory = new HaftedMorningStar(SaveGame);
    }

    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '\\';
    public override Colour Colour => Colour.Black;
    public override string Name => "The Morning Star 'Bloodspike'";
    public override int Ac => 0;
    public override int Cost => 30000;
    public override int Dd => 2;
    public override int Ds => 6;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.MorningStarBloodspike;
    public override string FriendlyName => "'Bloodspike'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override int Pval => 4;
    public override int Rarity => 30;
    public override bool ResNexus => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 22;
    public override int ToH => 8;
    public override int Weight => 150;
}
