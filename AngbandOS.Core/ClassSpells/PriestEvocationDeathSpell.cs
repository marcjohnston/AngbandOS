[Serializable]
internal class PriestEvocationDeathSpell : ClassSpell
{
    private PriestEvocationDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellEvocation);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 40;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 70;
}