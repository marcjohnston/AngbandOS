internal class MageCureLightWoundsFolkSpell : ClassSpell
{
    private MageCureLightWoundsFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellCureLightWounds);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 5;
    public override int BaseFailure => 44;
    public override int FirstCastExperience => 5;
}