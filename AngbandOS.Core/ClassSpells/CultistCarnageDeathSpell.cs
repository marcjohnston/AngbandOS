internal class CultistCarnageDeathSpell : ClassSpell
{
    private CultistCarnageDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellCarnage);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 44;
    public override int ManaCost => 45;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 25;
}