using AngbandOS.Core.Interface;
using AngbandOS.Core.ItemCategories;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LeadCrownOfTheUniverseFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    private LeadCrownOfTheUniverseFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<CrownLead>();
    }

    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => ']';
    public override Colour Colour => Colour.Black;
    public override string Name => "The Lead Crown of the Universe";
    public override int Ac => 0;
    public override bool Cha => true;
    public override bool Con => true;
    public override int Cost => 10000000;
    public override bool Cursed => true;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 1;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.CrownOfTheUniverse;
    public override string FriendlyName => "of the Universe";
    public override bool HeavyCurse => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    public override bool InstaArt => true;
    public override bool Int => true;
    public override int Level => 100;
    public override bool Lightsource => true;
    public override bool NoTele => true;
    public override bool PermaCurse => true;
    public override int Pval => 125;
    public override int Rarity => 1;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResConf => true;
    public override bool ResDark => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool ResNexus => true;
    public override bool ResPois => true;
    public override bool SeeInvis => true;
    public override bool Str => true;
    public override bool Telepathy => true;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 20;
    public override bool Wis => true;
}
