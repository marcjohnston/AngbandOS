[Serializable]
internal class RangerBlackSleepDeathSpell : ClassSpell
{
    private RangerBlackSleepDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellBlackSleep);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 8;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 3;
}