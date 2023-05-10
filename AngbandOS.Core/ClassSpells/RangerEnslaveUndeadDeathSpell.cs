[Serializable]
internal class RangerEnslaveUndeadDeathSpell : ClassSpell
{
    private RangerEnslaveUndeadDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellEnslaveUndead);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 22;
    public override int ManaCost => 22;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 3;
}