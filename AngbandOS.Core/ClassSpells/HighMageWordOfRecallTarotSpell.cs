[Serializable]
internal class HighMageWordOfRecallTarotSpell : ClassSpell
{
    private HighMageWordOfRecallTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellWordOfRecall);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 30;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 15;
}