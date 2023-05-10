internal class CultistEnslaveUndeadDeathSpell : ClassSpell
{
    private CultistEnslaveUndeadDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellEnslaveUndead);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 12;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}