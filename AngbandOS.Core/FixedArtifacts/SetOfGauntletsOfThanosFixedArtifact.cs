using AngbandOS.Core.ItemCategories;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SetOfGauntletsOfThanosFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    private SetOfGauntletsOfThanosFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<GlovesSetOfGauntlets>();
    }

    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => ']';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "The Set of Gauntlets of Thanos";
    public override int Ac => 2;
    public override bool Aggravate => true;
    public override int Cost => 0;
    public override bool Cursed => true;
    public override int Dd => 1;
    public override bool Dex => true;
    public override bool DreadCurse => true;
    public override int Ds => 1;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.GauntletOfThanos;
    public override string FriendlyName => "of Thanos";
    public override bool HeavyCurse => true;
    public override bool HideType => true;
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImCold => true;
    public override bool ImFire => true;
    public override int Level => 10;
    public override int Pval => 2;
    public override int Rarity => 20;
    public override bool ResChaos => true;
    public override bool ResDisen => true;
    public override bool ResNether => true;
    public override bool ResNexus => true;
    public override bool ResPois => true;
    public override bool ShowMods => true;
    public override bool Str => true;
    public override bool Teleport => true;
    public override int ToA => 0;
    public override int ToD => -12;
    public override int ToH => -11;
    public override int Weight => 25;
}
