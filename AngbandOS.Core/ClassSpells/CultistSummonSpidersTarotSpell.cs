internal class CultistSummonSpidersTarotSpell : ClassSpell
{
    private CultistSummonSpidersTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonSpiders);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 29;
    public override int ManaCost => 27;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 25;
}