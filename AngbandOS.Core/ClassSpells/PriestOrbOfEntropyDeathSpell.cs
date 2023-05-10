internal class PriestOrbOfEntropyDeathSpell : ClassSpell
{
    private PriestOrbOfEntropyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellOrbOfEntropy);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 14;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 5;
}