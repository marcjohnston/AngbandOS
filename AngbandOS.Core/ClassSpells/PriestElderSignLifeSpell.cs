internal class PriestElderSignLifeSpell : ClassSpell
{
    private PriestElderSignLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellElderSign);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 55;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 15;
}