[Serializable]
internal class HighMageIdentifyFolkSpell : ClassSpell
{
    private HighMageIdentifyFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellIdentify);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 32;
    public override int ManaCost => 28;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 25;
}