[Serializable]
internal class RogueDetectEvilDeathSpell : ClassSpell
{
    private RogueDetectEvilDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDetectEvil);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 5;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 1;
}