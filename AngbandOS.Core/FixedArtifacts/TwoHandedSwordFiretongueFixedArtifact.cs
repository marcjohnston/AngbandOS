using AngbandOS.ActivationPowers;
using AngbandOS.ArtifactBiases;
using AngbandOS.Core.ItemCategories;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TwoHandedSwordFiretongueFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    private TwoHandedSwordFiretongueFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<SwordTwoHandedSword>();
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
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "The Two-Handed Sword 'Firetongue'";
    public override int Ac => 0;
    public override bool Aggravate => true;
    public override bool BrandFire => true;
    public override bool Cha => true;
    public override int Cost => 205000;
    public override int Dd => 4;
    public override int Ds => 6;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.SwordFiretongue;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Firetongue'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    public override bool KillDragon => true;
    public override int Level => 30;
    public override bool Lightsource => true;
    public override int Pval => 4;
    public override int Rarity => 180;
    public override bool ResChaos => true;
    public override bool ResFire => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlayDemon => true;
    public override bool SlayEvil => true;
    public override bool SlayGiant => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool SlayUndead => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 21;
    public override int ToH => 19;
    public override bool Vorpal => true;
    public override int Weight => 250;
}
