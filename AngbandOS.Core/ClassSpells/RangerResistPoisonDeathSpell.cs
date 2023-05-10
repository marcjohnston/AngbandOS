[Serializable]
internal class RangerResistPoisonDeathSpell : ClassSpell
{
    private RangerResistPoisonDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellResistPoison);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 25;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 4;
}