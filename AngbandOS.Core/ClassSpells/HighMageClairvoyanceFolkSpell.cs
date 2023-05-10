[Serializable]
internal class HighMageClairvoyanceFolkSpell : ClassSpell
{
    private HighMageClairvoyanceFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellClairvoyance);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 46;
    public override int ManaCost => 80;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 200;
}