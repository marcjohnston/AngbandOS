internal class PriestMassCarnageDeathSpell : ClassSpell
{
    private PriestMassCarnageDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellMassCarnage);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 75;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 100;
}