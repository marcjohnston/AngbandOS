[Serializable]
internal class RangerResetRecallTarotSpell : ClassSpell
{
    private RangerResetRecallTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellResetRecall);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 8;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 8;
}