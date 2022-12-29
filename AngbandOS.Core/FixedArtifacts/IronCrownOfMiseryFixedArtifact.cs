using AngbandOS.ActivationPowers;
using AngbandOS.Core.ItemCategories;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class IronCrownOfMiseryFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    private IronCrownOfMiseryFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<CrownIron>();
    }

    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        item.BonusPowerType = Enumerations.RareItemType.SpecialAbility;
        item.BonusPowerSubType = ActivationPowerManager.GetRandom();
    }
    public override char Character => ']';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Iron Crown of Misery";
    public override int Ac => 0;
    public override bool Con => true;
    public override int Cost => 0;
    public override bool Cursed => true;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 1;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.CrownOfMisery;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Misery";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 40;
    public override int Pval => -25;
    public override int Rarity => 12;
    public override bool SeeInvis => true;
    public override bool Str => true;
    public override bool Telepathy => true;
    public override int ToA => 25;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 20;
}
