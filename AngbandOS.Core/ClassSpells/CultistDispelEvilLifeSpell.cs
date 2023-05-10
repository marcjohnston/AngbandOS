[Serializable]
internal class CultistDispelEvilLifeSpell : ClassSpell
{
    private CultistDispelEvilLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDispelEvil);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 38;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 75;
}