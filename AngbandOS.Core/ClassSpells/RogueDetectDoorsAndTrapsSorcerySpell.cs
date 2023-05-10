internal class RogueDetectDoorsAndTrapsSorcerySpell : ClassSpell
{
    private RogueDetectDoorsAndTrapsSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellDetectDoorsAndTraps);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 3;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 1;
}