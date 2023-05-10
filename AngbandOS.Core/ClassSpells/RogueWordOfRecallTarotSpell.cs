[Serializable]
internal class RogueWordOfRecallTarotSpell : ClassSpell
{
    private RogueWordOfRecallTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellWordOfRecall);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 46;
    public override int ManaCost => 44;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 15;
}