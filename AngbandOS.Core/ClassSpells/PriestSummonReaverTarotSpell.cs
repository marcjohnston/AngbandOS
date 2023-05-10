internal class PriestSummonReaverTarotSpell : ClassSpell
{
    private PriestSummonReaverTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonReaver);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 49;
    public override int ManaCost => 125;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 200;
}