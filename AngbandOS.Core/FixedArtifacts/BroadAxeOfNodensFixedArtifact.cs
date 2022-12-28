using AngbandOS.Core.Interface;
using AngbandOS.Core.ItemCategories;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class BroadAxeOfNodensFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    private BroadAxeOfNodensFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<PolearmBroadAxe>();
    }

    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '/';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Broad Axe of Nodens";
    public override int Ac => 0;
    public override bool Con => true;
    public override int Cost => 50000;
    public override int Dd => 2;
    public override int Ds => 6;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.AxeOfNodens;
    public override string FriendlyName => "of Nodens";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override int Pval => 3;
    public override int Rarity => 8;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayGiant => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override int ToA => 0;
    public override int ToD => 19;
    public override int ToH => 13;
    public override int Weight => 160;
}
