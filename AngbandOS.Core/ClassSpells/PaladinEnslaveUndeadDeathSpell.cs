[Serializable]
internal class PaladinEnslaveUndeadDeathSpell : ClassSpell
{
    private PaladinEnslaveUndeadDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellEnslaveUndead);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 15;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 5;
}