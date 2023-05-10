[Serializable]
internal class HighMageCureLightWoundsFolkSpell : ClassSpell
{
    private HighMageCureLightWoundsFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellCureLightWounds);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 4;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 5;
}