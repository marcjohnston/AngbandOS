[Serializable]
internal class RangerOrbOfEntropyDeathSpell : ClassSpell
{
    private RangerOrbOfEntropyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellOrbOfEntropy);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 24;
    public override int ManaCost => 24;
    public override int BaseFailure => 55;
    public override int FirstCastExperience => 3;
}