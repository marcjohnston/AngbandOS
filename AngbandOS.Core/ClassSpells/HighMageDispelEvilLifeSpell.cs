internal class HighMageDispelEvilLifeSpell : ClassSpell
{
    private HighMageDispelEvilLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDispelEvil);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 32;
    public override int ManaCost => 30;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 75;
}