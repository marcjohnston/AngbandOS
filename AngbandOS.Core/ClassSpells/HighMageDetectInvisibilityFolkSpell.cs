[Serializable]
internal class HighMageDetectInvisibilityFolkSpell : ClassSpell
{
    private HighMageDetectInvisibilityFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectInvisibility);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 23;
    public override int FirstCastExperience => 4;
}