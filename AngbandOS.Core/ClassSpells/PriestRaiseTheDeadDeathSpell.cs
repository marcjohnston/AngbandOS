[Serializable]
internal class PriestRaiseTheDeadDeathSpell : ClassSpell
{
    private PriestRaiseTheDeadDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellRaiseTheDead);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 25;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 50;
}