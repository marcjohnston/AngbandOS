[Serializable]
internal class HighMageBlinkFolkSpell : ClassSpell
{
    private HighMageBlinkFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellBlink);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 1;
    public override int BaseFailure => 23;
    public override int FirstCastExperience => 5;
}