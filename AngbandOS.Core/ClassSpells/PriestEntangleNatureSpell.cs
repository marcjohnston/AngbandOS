internal class PriestEntangleNatureSpell : ClassSpell
{
    private PriestEntangleNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellEntangle);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 20;
    public override int BaseFailure => 67;
    public override int FirstCastExperience => 7;
}