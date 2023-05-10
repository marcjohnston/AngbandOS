[Serializable]
internal class RogueEnslaveUndeadDeathSpell : ClassSpell
{
    private RogueEnslaveUndeadDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellEnslaveUndead);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 19;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 1;
}