internal class RogueSummonDemonTarotSpell : ClassSpell
{
    private RogueSummonDemonTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonDemon);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 49;
    public override int ManaCost => 125;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 150;
}