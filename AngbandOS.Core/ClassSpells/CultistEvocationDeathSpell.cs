internal class CultistEvocationDeathSpell : ClassSpell
{
    private CultistEvocationDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellEvocation);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 55;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 70;
}