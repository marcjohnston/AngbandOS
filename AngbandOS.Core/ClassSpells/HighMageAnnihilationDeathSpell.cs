internal class HighMageAnnihilationDeathSpell : ClassSpell
{
    private HighMageAnnihilationDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellAnnihilation);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 41;
    public override int ManaCost => 85;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 250;
}