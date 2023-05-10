internal class RangerExtradimensionalBeingTarotSpell : ClassSpell
{
    private RangerExtradimensionalBeingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellExtradimensionalBeing);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 44;
    public override int ManaCost => 120;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 250;
}