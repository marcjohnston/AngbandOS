using AngbandOS.ArtifactBiases;
using AngbandOS.Core.Interface;
using AngbandOS.Core.ItemCategories;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SmallMetalShieldVitriolFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    public SmallMetalShieldVitriolFixedArtifact(SaveGame saveGame) : base(saveGame)
     {
        _baseItemCategory = new ShieldSmallMetalShield(SaveGame);
    }

    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
    }
    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => ')';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Small Metal Shield 'Vitriol'";
    public override int Ac => 3;
    public override bool Con => true;
    public override int Cost => 60000;
    public override int Dd => 1;
    public override int Ds => 2;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.ShieldVitriol;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Vitriol'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImAcid => true;
    public override int Level => 30;
    public override int Pval => 4;
    public override int Rarity => 6;
    public override bool ResChaos => true;
    public override bool ResSound => true;
    public override bool Str => true;
    public override int ToA => 25;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 65;
}
