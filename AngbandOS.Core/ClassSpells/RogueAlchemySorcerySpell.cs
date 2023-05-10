internal class RogueAlchemySorcerySpell : ClassSpell
{
    private RogueAlchemySorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellAlchemy);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 50;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 100;
}