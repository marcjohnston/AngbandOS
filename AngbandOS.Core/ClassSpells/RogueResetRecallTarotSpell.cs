[Serializable]
internal class RogueResetRecallTarotSpell : ClassSpell
{
    private RogueResetRecallTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellResetRecall);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 9;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 8;
}