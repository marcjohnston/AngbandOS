[Serializable]
internal class MageOrbOfEntropyDeathSpell : ClassSpell
{
    private MageOrbOfEntropyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellOrbOfEntropy);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 12;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 5;
}