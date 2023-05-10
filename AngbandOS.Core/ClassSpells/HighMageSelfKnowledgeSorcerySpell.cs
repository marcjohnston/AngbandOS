[Serializable]
internal class HighMageSelfKnowledgeSorcerySpell : ClassSpell
{
    private HighMageSelfKnowledgeSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellSelfKnowledge);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 12;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 50;
}