internal class RogueSummonDragonTarotSpell : ClassSpell
{
    private RogueSummonDragonTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonDragon);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 46;
    public override int ManaCost => 100;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 150;
}