namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MightyHammerOfWorldsFixedArtifact : FixedArtifact
{
    private readonly ItemFactory _baseItemCategory;
    private MightyHammerOfWorldsFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<HaftedMightyHammer>();
    }

    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override char Character => '\\';
    public override Colour Colour => Colour.Black;
    public override string Name => "The Mighty Hammer of Worlds";
    public override int Ac => 0;
    public override bool Aggravate => true;
    public override int Cost => 500000;
    public override int Dd => 9;
    public override int Ds => 9;
    public override string FriendlyName => "of Worlds";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Impact => true;
    public override bool InstaArt => true;
    public override bool KillDragon => true;
    public override int Level => 100;
    public override bool NoMagic => true;
    public override int Pval => 0;
    public override int Rarity => 1;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlayDemon => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool SlayUndead => true;
    public override bool Telepathy => true;
    public override int ToA => 10;
    public override int ToD => 25;
    public override int ToH => 5;
    public override int Weight => 1000;
}
