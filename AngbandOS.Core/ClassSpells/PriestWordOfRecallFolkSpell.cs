[Serializable]
internal class PriestWordOfRecallFolkSpell : ClassSpell
{
    private PriestWordOfRecallFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellWordOfRecall);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 47;
    public override int ManaCost => 55;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 50;
}