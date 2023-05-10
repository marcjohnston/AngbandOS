internal class HighMageCureCriticalWoundsLifeSpell : ClassSpell
{
    private HighMageCureCriticalWoundsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCureCriticalWounds);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 15;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 4;
}