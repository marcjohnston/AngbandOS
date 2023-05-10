internal class PriestResetRecallTarotSpell : ClassSpell
{
    private PriestResetRecallTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellResetRecall);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 8;
}