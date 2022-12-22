using AngbandOS.Core.Interface;
using AngbandOS.Core.ItemCategories;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class CutlassOfBlackbeardFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    private CutlassOfBlackbeardFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<SwordCutlass>();
    }

    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "The Cutlass of Blackbeard";
    public override int Ac => 0;
    public override int Cost => 28000;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 7;
    public override bool Feather => true;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.CutlassOfBlackbeard;
    public override string FriendlyName => "of Blackbeard";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override int Pval => 3;
    public override int Rarity => 8;
    public override bool Regen => true;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool Stealth => true;
    public override int ToA => 0;
    public override int ToD => 11;
    public override int ToH => 10;
    public override int Weight => 110;
}
