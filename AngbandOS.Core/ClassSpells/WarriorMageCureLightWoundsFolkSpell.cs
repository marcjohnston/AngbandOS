[Serializable]
internal class WarriorMageCureLightWoundsFolkSpell : ClassSpell
{
    private WarriorMageCureLightWoundsFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellCureLightWounds);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 44;
    public override int FirstCastExperience => 5;
}