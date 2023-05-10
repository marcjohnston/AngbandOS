internal class PriestResistPoisonDeathSpell : ClassSpell
{
    private PriestResistPoisonDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellResistPoison);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 11;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 6;
}