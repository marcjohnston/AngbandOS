internal class PriestVampiricDrainDeathSpell : ClassSpell
{
    private PriestVampiricDrainDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellVampiricDrain);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 24;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 16;
}