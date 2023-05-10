internal class RogueSummonHoundsTarotSpell : ClassSpell
{
    private RogueSummonHoundsTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonHounds);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 33;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 35;
}