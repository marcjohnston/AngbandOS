[Serializable]
internal class RangerSummonHoundsTarotSpell : ClassSpell
{
    private RangerSummonHoundsTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonHounds);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 36;
    public override int ManaCost => 33;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 35;
}