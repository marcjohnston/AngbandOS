using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;
using AngbandOS.ArtifactBiases;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LeatherScaleMailWyvernscaleFixedArtifact : BaseFixedArtifact
{
    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
    }
    public override ItemClass BaseItemCategory => new SoftArmorLeatherScaleMail();

    public override char Character => '(';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "The Leather Scale Mail 'Wyvernscale'";
    public override int Ac => 11;
    public override int Cost => 25000;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 1;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.ScaleMailWyvernscale;
    public override string FriendlyName => "'Wyvernscale'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override int Pval => 3;
    public override int Rarity => 3;
    public override bool ResAcid => true;
    public override bool ResShards => true;
    public override int ToA => 25;
    public override int ToD => 0;
    public override int ToH => -1;
    public override int Weight => 60;
}
