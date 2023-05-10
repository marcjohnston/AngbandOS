[Serializable]
internal class PaladinResistPoisonDeathSpell : ClassSpell
{
    private PaladinResistPoisonDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellResistPoison);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 11;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 6;
}