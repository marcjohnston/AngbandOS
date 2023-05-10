[Serializable]
internal class HighMageDetectionFolkSpell : ClassSpell
{
    private HighMageDetectionFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetection);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 41;
    public override int ManaCost => 28;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 40;
}