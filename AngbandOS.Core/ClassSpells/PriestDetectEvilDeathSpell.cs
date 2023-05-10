[Serializable]
internal class PriestDetectEvilDeathSpell : ClassSpell
{
    private PriestDetectEvilDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDetectEvil);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 3;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 4;
}