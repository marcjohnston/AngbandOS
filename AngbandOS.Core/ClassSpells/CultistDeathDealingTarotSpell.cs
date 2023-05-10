internal class CultistDeathDealingTarotSpell : ClassSpell
{
    private CultistDeathDealingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellDeathDealing);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 46;
    public override int ManaCost => 55;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 75;
}