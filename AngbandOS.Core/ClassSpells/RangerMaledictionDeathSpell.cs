[Serializable]
internal class RangerMaledictionDeathSpell : ClassSpell
{
    private RangerMaledictionDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellMalediction);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 3;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 3;
}