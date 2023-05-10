internal class RangerWordOfRecallTarotSpell : ClassSpell
{
    private RangerWordOfRecallTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellWordOfRecall);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 42;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 15;
}