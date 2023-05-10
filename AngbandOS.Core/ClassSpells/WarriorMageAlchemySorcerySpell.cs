internal class WarriorMageAlchemySorcerySpell : ClassSpell
{
    private WarriorMageAlchemySorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellAlchemy);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 46;
    public override int ManaCost => 55;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 175;
}