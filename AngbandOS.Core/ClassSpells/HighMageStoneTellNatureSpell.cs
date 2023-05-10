internal class HighMageStoneTellNatureSpell : ClassSpell
{
    private HighMageStoneTellNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellStoneTell);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 35;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 200;
}