using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;
using AngbandOS.ArtifactBiases;
using AngbandOS.ActivationPowers;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class IronHelmTerrorMaskFixedArtifact : BaseFixedArtifact, IActivatible
{
    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        if (saveGame.Player.ProfessionIndex == CharacterClass.Warrior)
        {
            item.BonusPowerType = Enumerations.RareItemType.SpecialAbility;
            item.BonusPowerSubType = ActivationPowerManager.GetRandom();

            IArtifactBias artifactBias = null;
            item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
        }
        else
        {
            item.RandartItemCharacteristics.Cursed = true;
            item.RandartItemCharacteristics.HeavyCurse = true;
            item.RandartItemCharacteristics.Aggravate = true;
            item.RandartItemCharacteristics.DreadCurse = true;
            item.IdentCursed = true;
            return;
        }
    }

    // Dragon Helm and Terror Mask cause fear
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.TurnMonsters(40 + saveGame.Player.Level);
        item.RechargeTimeLeft = 3 * (saveGame.Player.Level + 10);
    }
    public string DescribeActivationEffect() => "rays of fear in every direction";
    public override ItemClass BaseItemCategory => new HelmIronHelm();
    public override char Character => ']';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Iron Helm 'Terror Mask'";
    public override int Ac => 5;
    public override bool Activate => true;
    public override int Cost => 0;
    public override int Dd => 1;
    public override int Ds => 3;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.HelmTerrorMask;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Terror Mask'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImCold => true;
    public override bool Int => true;
    public override int Level => 20;
    public override bool NoMagic => true;
    public override int Pval => -1;
    public override int Rarity => 5;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResDisen => true;
    public override bool ResFear => true;
    public override bool ResPois => true;
    public override bool Search => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool Teleport => true;
    public override int ToA => 10;
    public override int ToD => 25;
    public override int ToH => 25;
    public override int Weight => 75;
    public override bool Wis => true;
}