internal class CultistOrbOfEntropyDeathSpell : ClassSpell
{
    private CultistOrbOfEntropyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellOrbOfEntropy);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 14;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 5;
}