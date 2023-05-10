[Serializable]
internal class CultistRaiseTheDeadDeathSpell : ClassSpell
{
    private CultistRaiseTheDeadDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellRaiseTheDead);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 24;
    public override int ManaCost => 24;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 50;
}