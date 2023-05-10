[Serializable]
internal class MonkSummonHoundsTarotSpell : ClassSpell
{
    private MonkSummonHoundsTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonHounds);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 30;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 35;
}