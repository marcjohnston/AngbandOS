internal class RogueWordOfRecallFolkSpell : ClassSpell
{
    private RogueWordOfRecallFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellWordOfRecall);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 49;
    public override int ManaCost => 65;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 50;
}