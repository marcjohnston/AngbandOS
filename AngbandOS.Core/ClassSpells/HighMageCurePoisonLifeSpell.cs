internal class HighMageCurePoisonLifeSpell : ClassSpell
{
    private HighMageCurePoisonLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCurePoison);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 14;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 4;
}