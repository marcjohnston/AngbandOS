using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;
using AngbandOS.ArtifactBiases;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MetalBrigandineArmourOfSerpentsFixedArtifact : BaseFixedArtifact
{
    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
    }
    public override ItemClass BaseItemCategory => new HardArmorMetalBrigandineArmour();

    public override char Character => '[';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Metal Brigandine Armour of Serpents";
    public override int Ac => 19;
    public override int Cost => 30000;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 4;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.ArmourOfSerpents;
    public override string FriendlyName => "of Serpents";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 30;
    public override int Pval => 2;
    public override int Rarity => 3;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResConf => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResSound => true;
    public override bool Str => true;
    public override int ToA => 15;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 200;
}