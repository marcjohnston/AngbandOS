[Serializable]
internal class HighMageDetectObjectsFolkSpell : ClassSpell
{
    private HighMageDetectObjectsFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectObjects);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 8;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 6;
}