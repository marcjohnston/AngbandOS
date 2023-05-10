[Serializable]
internal class RogueSelfKnowledgeSorcerySpell : ClassSpell
{
    private RogueSelfKnowledgeSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellSelfKnowledge);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 20;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 20;
}