[Serializable]
internal class MageCureMediumWoundsFolkSpell : ClassSpell
{
    private MageCureMediumWoundsFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellCureMediumWounds);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 16;
    public override int ManaCost => 14;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 6;
}