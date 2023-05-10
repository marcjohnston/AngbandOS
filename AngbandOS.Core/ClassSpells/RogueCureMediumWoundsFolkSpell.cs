[Serializable]
internal class RogueCureMediumWoundsFolkSpell : ClassSpell
{
    private RogueCureMediumWoundsFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellCureMediumWounds);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 19;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 6;
}