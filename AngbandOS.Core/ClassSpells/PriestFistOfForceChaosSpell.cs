internal class PriestFistOfForceChaosSpell : ClassSpell
{
    private PriestFistOfForceChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFistOfForce);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 16;
    public override int ManaCost => 11;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}