internal class HighMageRestoreLifeDeathSpell : ClassSpell
{
    private HighMageRestoreLifeDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellRestoreLife);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 40;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 150;
}