using AngbandOS.ArtifactBiases;
using AngbandOS.Core.Interface;
using AngbandOS.Core.ItemCategories;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LargeMetalShieldOfStabilityFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    public LargeMetalShieldOfStabilityFixedArtifact(SaveGame saveGame) : base(saveGame)
     {
        _baseItemCategory = new ShieldLargeMetalShield(SaveGame);
    }

    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
    }
    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => ')';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Large Metal Shield of Stability";
    public override int Ac => 5;
    public override int Cost => 160000;
    public override int Dd => 1;
    public override int Ds => 3;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.ShieldOfStability;
    public override string FriendlyName => "of Stability";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 40;
    public override int Pval => 0;
    public override int Rarity => 9;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool SustCha => true;
    public override bool SustCon => true;
    public override bool SustDex => true;
    public override bool SustInt => true;
    public override bool SustStr => true;
    public override bool SustWis => true;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 120;
}
