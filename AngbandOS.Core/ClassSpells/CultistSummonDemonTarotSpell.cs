internal class CultistSummonDemonTarotSpell : ClassSpell
{
    private CultistSummonDemonTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonDemon);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 125;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 150;
}