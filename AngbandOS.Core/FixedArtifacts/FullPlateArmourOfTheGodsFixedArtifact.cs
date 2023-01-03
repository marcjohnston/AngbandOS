namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class FullPlateArmourOfTheGodsFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    private FullPlateArmourOfTheGodsFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<HardArmorFullPlateArmour>();
    }

    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '[';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "The Full Plate Armour of the Gods";
    public override int Ac => 25;
    public override bool Con => true;
    public override int Cost => 50000;
    public override int Dd => 2;
    public override int Ds => 4;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.ArmourOfTheGods;
    public override string FriendlyName => "of the Gods";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 30;
    public override int Pval => 1;
    public override int Rarity => 3;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResConf => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResNexus => true;
    public override bool ResSound => true;
    public override int ToA => 25;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 300;
}
