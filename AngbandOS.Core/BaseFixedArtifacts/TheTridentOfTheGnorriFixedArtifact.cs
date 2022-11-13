using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TheTridentOfTheGnorriFixedArtifact : Base2FixedArtifact
{
    public override ItemClass BaseItemCategory => new PolearmTrident();

    public override char Character => '/';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "The Trident of the Gnorri";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Blessed => true;
    public override int Cost => 120000;
    public override int Dd => 4;
    public override bool Dex => true;
    public override int Ds => 8;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.TridentOfTheGnorri;
    public override bool FreeAct => true;
    public override string FriendlyName => "of the Gnorri";
    public override bool HideType => true;
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImAcid => true;
    public override int Level => 30;
    public override int Pval => 4;
    public override int Rarity => 90;
    public override bool Regen => true;
    public override bool ResNether => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlayDragon => true;
    public override bool SlowDigest => true;
    public override int ToA => 0;
    public override int ToD => 19;
    public override int ToH => 15;
    public override int Weight => 70;
}
