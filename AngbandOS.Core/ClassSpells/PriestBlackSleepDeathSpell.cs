[Serializable]
internal class PriestBlackSleepDeathSpell : ClassSpell
{
    private PriestBlackSleepDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellBlackSleep);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}