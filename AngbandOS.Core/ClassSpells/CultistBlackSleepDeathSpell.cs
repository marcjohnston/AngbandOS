internal class CultistBlackSleepDeathSpell : ClassSpell
{
    private CultistBlackSleepDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellBlackSleep);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}