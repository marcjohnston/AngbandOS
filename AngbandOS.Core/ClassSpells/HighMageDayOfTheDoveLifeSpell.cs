internal class HighMageDayOfTheDoveLifeSpell : ClassSpell
{
    private HighMageDayOfTheDoveLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDayOfTheDove);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 31;
    public override int ManaCost => 30;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 75;
}