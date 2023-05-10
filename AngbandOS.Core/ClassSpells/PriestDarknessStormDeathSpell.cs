internal class PriestDarknessStormDeathSpell : ClassSpell
{
    private PriestDarknessStormDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDarknessStorm);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 44;
    public override int ManaCost => 44;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 200;
}