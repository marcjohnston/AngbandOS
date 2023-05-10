[Serializable]
internal class WarriorMageWordOfRecallSorcerySpell : ClassSpell
{
    private WarriorMageWordOfRecallSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellWordOfRecall);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 28;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 19;
}