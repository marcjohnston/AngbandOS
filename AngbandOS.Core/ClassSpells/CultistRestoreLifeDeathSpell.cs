internal class CultistRestoreLifeDeathSpell : ClassSpell
{
    private CultistRestoreLifeDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellRestoreLife);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 55;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 150;
}