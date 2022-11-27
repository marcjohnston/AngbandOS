using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;
using AngbandOS.ArtifactBiases;
using AngbandOS.ActivationPowers;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class WarHammerMjolnirFixedArtifact : BaseFixedArtifact
{
    public override ItemClass BaseItemCategory => new HaftedWarHammer();

    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        item.BonusPowerType = Enumerations.RareItemType.SpecialAbility;
        item.BonusPowerSubType = ActivationPowerManager.GetRandom();

        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
    }
    public override char Character => '\\';
    public override Colour Colour => Colour.Black;
    public override string Name => "The War Hammer 'Mjolnir'";
    public override int Ac => 0;
    public override bool BrandElec => true;
    public override int Cost => 250000;
    public override int Dd => 9;
    public override int Ds => 3;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.HammerMjolnir;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Mjolnir'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool KillDragon => true;
    public override int Level => 40;
    public override int Pval => 4;
    public override int Rarity => 75;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResNexus => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayEvil => true;
    public override bool SlayUndead => true;
    public override int ToA => 5;
    public override int ToD => 21;
    public override int ToH => 19;
    public override int Weight => 120;
    public override bool Wis => true;
}
