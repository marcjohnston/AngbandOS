internal class CultistWordOfRecallFolkSpell : ClassSpell
{
    private CultistWordOfRecallFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellWordOfRecall);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 65;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 50;
}