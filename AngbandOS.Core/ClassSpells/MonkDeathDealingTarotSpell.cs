internal class MonkDeathDealingTarotSpell : ClassSpell
{
    private MonkDeathDealingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellDeathDealing);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 55;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 75;
}