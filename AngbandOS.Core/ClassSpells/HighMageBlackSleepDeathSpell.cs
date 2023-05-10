[Serializable]
internal class HighMageBlackSleepDeathSpell : ClassSpell
{
    private HighMageBlackSleepDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellBlackSleep);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 3;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 4;
}