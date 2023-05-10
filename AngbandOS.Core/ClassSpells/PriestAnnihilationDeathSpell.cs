internal class PriestAnnihilationDeathSpell : ClassSpell
{
    private PriestAnnihilationDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellAnnihilation);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 49;
    public override int ManaCost => 100;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 250;
}