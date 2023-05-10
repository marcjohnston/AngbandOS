[Serializable]
internal class HighMageResistAcidFolkSpell : ClassSpell
{
    private HighMageResistAcidFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellResistAcid);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 10;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 5;
}