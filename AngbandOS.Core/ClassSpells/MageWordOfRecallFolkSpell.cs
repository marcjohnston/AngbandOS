internal class MageWordOfRecallFolkSpell : ClassSpell
{
    private MageWordOfRecallFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellWordOfRecall);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 50;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 50;
}