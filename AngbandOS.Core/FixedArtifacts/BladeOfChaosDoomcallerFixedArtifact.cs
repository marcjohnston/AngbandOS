using AngbandOS.Core.Interface;
using AngbandOS.Core.ItemCategories;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class BladeOfChaosDoomcallerFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    public BladeOfChaosDoomcallerFixedArtifact(SaveGame saveGame) : base(saveGame)
     {
        _baseItemCategory = new SwordBladeofChaos(SaveGame);
    }

    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '|';
    public override Colour Colour => Colour.Purple;
    public override string Name => "The Blade of Chaos 'Doomcaller'";
    public override int Ac => 0;
    public override bool Aggravate => true;
    public override bool BrandCold => true;
    public override bool BrandFire => true;
    public override bool BrandPois => true;
    public override bool Chaotic => true;
    public override int Cost => 250000;
    public override int Dd => 6;
    public override int Ds => 5;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.BladeDoomcaller;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Doomcaller'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool KillDragon => true;
    public override int Level => 70;
    public override bool Lightsource => true;
    public override int Pval => 0;
    public override int Rarity => 25;
    public override bool ResAcid => true;
    public override bool ResChaos => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool Telepathy => true;
    public override int ToA => -50;
    public override int ToD => 28;
    public override int ToH => 18;
    public override bool Vorpal => true;
    public override int Weight => 180;
}
