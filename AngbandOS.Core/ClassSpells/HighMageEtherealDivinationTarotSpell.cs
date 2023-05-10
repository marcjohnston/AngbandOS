internal class HighMageEtherealDivinationTarotSpell : ClassSpell
{
    private HighMageEtherealDivinationTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellEtherealDivination);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 25;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 50;
}