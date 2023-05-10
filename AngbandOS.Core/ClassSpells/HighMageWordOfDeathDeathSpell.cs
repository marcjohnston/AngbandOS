internal class HighMageWordOfDeathDeathSpell : ClassSpell
{
    private HighMageWordOfDeathDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellWordOfDeath);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 29;
    public override int ManaCost => 30;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 40;
}