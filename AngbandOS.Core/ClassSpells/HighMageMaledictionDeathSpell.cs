[Serializable]
internal class HighMageMaledictionDeathSpell : ClassSpell
{
    private HighMageMaledictionDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellMalediction);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 4;
}