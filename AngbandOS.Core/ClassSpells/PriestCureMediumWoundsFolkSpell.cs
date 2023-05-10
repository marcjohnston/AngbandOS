[Serializable]
internal class PriestCureMediumWoundsFolkSpell : ClassSpell
{
    private PriestCureMediumWoundsFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellCureMediumWounds);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 18;
    public override int ManaCost => 17;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 6;
}