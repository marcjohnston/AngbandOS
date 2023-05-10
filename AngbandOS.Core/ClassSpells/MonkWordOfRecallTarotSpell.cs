internal class MonkWordOfRecallTarotSpell : ClassSpell
{
    private MonkWordOfRecallTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellWordOfRecall);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 40;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 15;
}