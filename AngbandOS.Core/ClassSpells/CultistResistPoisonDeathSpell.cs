[Serializable]
internal class CultistResistPoisonDeathSpell : ClassSpell
{
    private CultistResistPoisonDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellResistPoison);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 10;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 6;
}