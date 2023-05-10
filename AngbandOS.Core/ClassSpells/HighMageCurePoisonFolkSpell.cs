internal class HighMageCurePoisonFolkSpell : ClassSpell
{
    private HighMageCurePoisonFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellCurePoison);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 9;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 6;
}