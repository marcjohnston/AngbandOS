internal class WarriorMageStoneToMudFolkSpell : ClassSpell
{
    private WarriorMageStoneToMudFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellStoneToMud);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 23;
    public override int ManaCost => 22;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 9;
}