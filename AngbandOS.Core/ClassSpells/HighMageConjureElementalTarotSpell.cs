internal class HighMageConjureElementalTarotSpell : ClassSpell
{
    private HighMageConjureElementalTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellConjureElemental);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 26;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 12;
}