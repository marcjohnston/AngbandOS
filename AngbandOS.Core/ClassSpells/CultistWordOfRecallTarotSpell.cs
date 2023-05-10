[Serializable]
internal class CultistWordOfRecallTarotSpell : ClassSpell
{
    private CultistWordOfRecallTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellWordOfRecall);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 44;
    public override int ManaCost => 42;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 15;
}