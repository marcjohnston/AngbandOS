[Serializable]
internal class MageWordOfRecallSorcerySpell : ClassSpell
{
    private MageWordOfRecallSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellWordOfRecall);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 25;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 19;
}