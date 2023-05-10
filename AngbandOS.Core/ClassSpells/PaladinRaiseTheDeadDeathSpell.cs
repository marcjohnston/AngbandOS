[Serializable]
internal class PaladinRaiseTheDeadDeathSpell : ClassSpell
{
    private PaladinRaiseTheDeadDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellRaiseTheDead);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 35;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 50;
}