[Serializable]
internal class MageWordOfRecallTarotSpell : ClassSpell
{
    private MageWordOfRecallTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellWordOfRecall);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 35;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 15;
}