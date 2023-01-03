namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LongSwordVorpalBladeFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    private LongSwordVorpalBladeFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<SwordLongSword>();
    }

    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "The Long Sword 'Vorpal Blade'";
    public override int Ac => 0;
    public override int Cost => 250000;
    public override int Dd => 5;
    public override bool Dex => true;
    public override int Ds => 5;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.SwordVorpalBlade;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Vorpal Blade'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 50;
    public override bool Lightsource => true;
    public override int Pval => 2;
    public override int Rarity => 30;
    public override bool Regen => true;
    public override bool SeeInvis => true;
    public override bool SlayEvil => true;
    public override bool SlowDigest => true;
    public override bool Speed => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 32;
    public override int ToH => 32;
    public override bool Vorpal => true;
    public override int Weight => 150;
}
