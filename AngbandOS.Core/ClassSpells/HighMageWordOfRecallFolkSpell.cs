[Serializable]
internal class HighMageWordOfRecallFolkSpell : ClassSpell
{
    private HighMageWordOfRecallFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellWordOfRecall);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 43;
    public override int ManaCost => 40;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 50;
}