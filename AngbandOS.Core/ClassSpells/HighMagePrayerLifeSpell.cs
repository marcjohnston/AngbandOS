internal class HighMagePrayerLifeSpell : ClassSpell
{
    private HighMagePrayerLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellPrayer);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 20;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 40;
}