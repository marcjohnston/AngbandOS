using AngbandOS.ArtifactBiases;
using AngbandOS.Core.Interface;
using AngbandOS.Core.ItemCategories;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class PairOfMetalShodBootsOfTheBlackReaverFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    private PairOfMetalShodBootsOfTheBlackReaverFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<BootsMetalShodBoots>();
    }

    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
    }
    public override char Character => ']';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Pair of Metal Shod Boots of the Black Reaver";
    public override int Ac => 6;
    public override bool Aggravate => true;
    public override bool Con => true;
    public override int Cost => 15000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.BootsOfTheBlackReaver;
    public override string FriendlyName => "of the Black Reaver";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 30;
    public override int Pval => 10;
    public override int Rarity => 25;
    public override bool Speed => true;
    public override bool Str => true;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 80;
}
