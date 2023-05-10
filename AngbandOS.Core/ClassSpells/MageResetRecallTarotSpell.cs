[Serializable]
internal class MageResetRecallTarotSpell : ClassSpell
{
    private MageResetRecallTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellResetRecall);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 6;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 8;
}