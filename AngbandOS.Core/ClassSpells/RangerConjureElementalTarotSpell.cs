internal class RangerConjureElementalTarotSpell : ClassSpell
{
    private RangerConjureElementalTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellConjureElemental);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 33;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 12;
}