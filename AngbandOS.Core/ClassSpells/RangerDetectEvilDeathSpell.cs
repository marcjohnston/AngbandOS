[Serializable]
internal class RangerDetectEvilDeathSpell : ClassSpell
{
    private RangerDetectEvilDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDetectEvil);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 4;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 3;
}