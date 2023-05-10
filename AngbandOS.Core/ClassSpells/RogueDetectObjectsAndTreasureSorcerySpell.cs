internal class RogueDetectObjectsAndTreasureSorcerySpell : ClassSpell
{
    private RogueDetectObjectsAndTreasureSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellDetectObjectsAndTreasure);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 3;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 5;
}