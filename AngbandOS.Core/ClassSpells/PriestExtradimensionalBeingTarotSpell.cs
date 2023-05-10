internal class PriestExtradimensionalBeingTarotSpell : ClassSpell
{
    private PriestExtradimensionalBeingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellExtradimensionalBeing);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 41;
    public override int ManaCost => 110;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 250;
}