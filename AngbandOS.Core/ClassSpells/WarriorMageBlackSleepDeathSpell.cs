[Serializable]
internal class WarriorMageBlackSleepDeathSpell : ClassSpell
{
    private WarriorMageBlackSleepDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellBlackSleep);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}