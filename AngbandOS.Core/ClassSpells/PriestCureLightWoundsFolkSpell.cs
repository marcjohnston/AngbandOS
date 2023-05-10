[Serializable]
internal class PriestCureLightWoundsFolkSpell : ClassSpell
{
    private PriestCureLightWoundsFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellCureLightWounds);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 6;
    public override int BaseFailure => 44;
    public override int FirstCastExperience => 5;
}