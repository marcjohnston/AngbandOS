[Serializable]
internal class RogueCureLightWoundsFolkSpell : ClassSpell
{
    private RogueCureLightWoundsFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellCureLightWounds);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 8;
    public override int BaseFailure => 44;
    public override int FirstCastExperience => 5;
}