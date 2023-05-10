internal class RogueDeathDealingTarotSpell : ClassSpell
{
    private RogueDeathDealingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellDeathDealing);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 75;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 75;
}