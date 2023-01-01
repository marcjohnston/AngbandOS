using AngbandOS.ActivationPowers;
using AngbandOS.Core.ItemCategories;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LongBowOfSerpentsFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    private LongBowOfSerpentsFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<BowLong>();
    }

    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        if (Program.Rng.DieRoll(2) == 1)
        {
            IArtifactBias artifactBias = null;
            item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
        }
        else
        {
            item.BonusPowerType = Enumerations.RareItemType.SpecialAbility;
            item.BonusPowerSubType = ActivationPowerManager.GetRandom();
        }
    }
    public override char Character => '}';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "The Long Bow of Serpents";
    public override int Ac => 0;
    public override int Cost => 20000;
    public override int Dd => 0;
    public override bool Dex => true;
    public override int Ds => 0;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.BowOfSerpents;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Serpents";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 30;
    public override int Pval => 3;
    public override int Rarity => 20;
    public override bool ShowMods => true;
    public override int ToA => 0;
    public override int ToD => 19;
    public override int ToH => 17;
    public override int Weight => 40;
    public override bool XtraMight => true;
}
