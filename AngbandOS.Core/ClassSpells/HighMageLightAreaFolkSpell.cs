[Serializable]
internal class HighMageLightAreaFolkSpell : ClassSpell
{
    private HighMageLightAreaFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellLightArea);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 2;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 6;
}