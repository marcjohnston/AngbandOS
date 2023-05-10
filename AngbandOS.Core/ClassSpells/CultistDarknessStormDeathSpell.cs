internal class CultistDarknessStormDeathSpell : ClassSpell
{
    private CultistDarknessStormDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDarknessStorm);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 50;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 200;
}