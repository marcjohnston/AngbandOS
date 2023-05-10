internal class MageAlchemySorcerySpell : ClassSpell
{
    private MageAlchemySorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellAlchemy);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 50;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 175;
}