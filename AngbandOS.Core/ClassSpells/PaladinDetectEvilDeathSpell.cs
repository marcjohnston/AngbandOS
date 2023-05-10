[Serializable]
internal class PaladinDetectEvilDeathSpell : ClassSpell
{
    private PaladinDetectEvilDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDetectEvil);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 3;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 4;
}