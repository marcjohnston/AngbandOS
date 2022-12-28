using AngbandOS.Core.Interface;
using AngbandOS.Core.ItemCategories;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class GlaiveOfPainFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    private GlaiveOfPainFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<PolearmGlaive>();
    }

    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '/';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Glaive of Pain";
    public override int Ac => 0;
    public override int Cost => 50000;
    public override int Dd => 9;
    public override int Ds => 6;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.GlaiveOfPain;
    public override string FriendlyName => "of Pain";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 30;
    public override int Pval => 0;
    public override int Rarity => 25;
    public override bool ShowMods => true;
    public override int ToA => 0;
    public override int ToD => 30;
    public override int ToH => 0;
    public override int Weight => 190;
}
