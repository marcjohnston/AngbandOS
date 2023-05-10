internal class WarriorMageCureMediumWoundsFolkSpell : ClassSpell
{
    private WarriorMageCureMediumWoundsFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellCureMediumWounds);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 18;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 6;
}