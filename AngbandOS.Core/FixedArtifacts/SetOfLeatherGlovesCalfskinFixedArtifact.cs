using AngbandOS.Core.ItemCategories;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SetOfLeatherGlovesCalfskinFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    private SetOfLeatherGlovesCalfskinFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<GlovesSetOfLeatherGloves>();
    }

    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => ']';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "The Set of Leather Gloves 'Calfskin'";
    public override int Ac => 1;
    public override bool Con => true;
    public override int Cost => 36000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.GlovesCalfskin;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Calfskin'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 10;
    public override int Pval => 2;
    public override int Rarity => 6;
    public override bool ShowMods => true;
    public override bool Str => true;
    public override int ToA => 15;
    public override int ToD => 8;
    public override int ToH => 8;
    public override int Weight => 5;
}
