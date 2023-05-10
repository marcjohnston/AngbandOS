internal class PaladinOrbOfEntropyDeathSpell : ClassSpell
{
    private PaladinOrbOfEntropyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellOrbOfEntropy);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 17;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 5;
}