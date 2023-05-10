internal class PriestCarnageDeathSpell : ClassSpell
{
    private PriestCarnageDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellCarnage);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 30;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 100;
}