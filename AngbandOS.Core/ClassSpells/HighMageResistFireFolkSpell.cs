[Serializable]
internal class HighMageResistFireFolkSpell : ClassSpell
{
    private HighMageResistFireFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellResistFire);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 10;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 5;
}