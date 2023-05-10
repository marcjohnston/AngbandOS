internal class HighMageEntangleNatureSpell : ClassSpell
{
    private HighMageEntangleNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellEntangle);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 10;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 7;
}