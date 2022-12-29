using AngbandOS.ActivationPowers;
using AngbandOS.ArtifactBiases;
using AngbandOS.Core.ItemCategories;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TwoHandedSwordDragonslayerFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    private TwoHandedSwordDragonslayerFixedArtifact(SaveGame saveGame)
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
    public override string Name => "The Two-Handed Sword 'Dragonslayer'";
    public override int Ac => 0;
    public override int Cost => 100000;
    public override int Dd => 3;
    public override int Ds => 6;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.SwordDragonSlayer;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Dragonslayer'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool KillDragon => true;
    public override int Level => 30;
    public override int Pval => 2;
    public override int Rarity => 30;
    public override bool Regen => true;
    public override bool ShowMods => true;
    public override bool SlayTroll => true;
    public override bool SlowDigest => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 17;
    public override int ToH => 13;
    public override int Weight => 200;
}
