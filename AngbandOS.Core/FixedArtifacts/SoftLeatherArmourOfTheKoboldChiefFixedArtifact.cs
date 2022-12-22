using AngbandOS.ArtifactBiases;
using AngbandOS.Core.Interface;
using AngbandOS.Core.ItemCategories;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SoftLeatherArmourOfTheKoboldChiefFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    private SoftLeatherArmourOfTheKoboldChiefFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<SoftArmorSoftLeatherArmour>();
    }

    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
    }
    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '(';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "The Soft Leather Armour of the Kobold Chief";
    public override int Ac => 4;
    public override int Cost => 45000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.ArmourOfTheKoboldChief;
    public override string FriendlyName => "of the Kobold Chief";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override int Pval => 4;
    public override int Rarity => 3;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResDark => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool Stealth => true;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 80;
}
