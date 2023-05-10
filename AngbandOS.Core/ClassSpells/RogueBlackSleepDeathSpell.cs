internal class RogueBlackSleepDeathSpell : ClassSpell
{
    private RogueBlackSleepDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellBlackSleep);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 7;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 1;
}