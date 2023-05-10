internal class RogueSummonUndeadTarotSpell : ClassSpell
{
    private RogueSummonUndeadTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonUndead);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 44;
    public override int ManaCost => 100;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 150;
}