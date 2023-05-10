internal class HighMageResistLightningFolkSpell : ClassSpell
{
    private HighMageResistLightningFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellResistLightning);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 10;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 5;
}