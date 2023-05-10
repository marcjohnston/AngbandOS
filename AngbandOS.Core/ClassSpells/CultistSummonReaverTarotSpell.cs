internal class CultistSummonReaverTarotSpell : ClassSpell
{
    private CultistSummonReaverTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonReaver);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 135;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 200;
}