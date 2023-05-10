[Serializable]
internal class RangerCureLightWoundsFolkSpell : ClassSpell
{
    private RangerCureLightWoundsFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellCureLightWounds);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 8;
    public override int BaseFailure => 44;
    public override int FirstCastExperience => 5;
}