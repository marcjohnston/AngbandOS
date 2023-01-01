using AngbandOS.ActivationPowers;
using AngbandOS.Core.ItemCategories;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MainGaucheOfDefenceFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    private MainGaucheOfDefenceFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<SwordMainGauche>();
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
    public override string Name => "The Main Gauche of Defence";
    public override int Ac => 0;
    public override int Cost => 22500;
    public override int Dd => 2;
    public override bool Dex => true;
    public override int Ds => 5;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.MainGaucheOfDefence;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Defence";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override int Level => 15;
    public override int Pval => 3;
    public override int Rarity => 30;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayGiant => true;
    public override bool SlayTroll => true;
    public override bool Speed => true;
    public override int ToA => 0;
    public override int ToD => 15;
    public override int ToH => 12;
    public override int Weight => 30;
}
