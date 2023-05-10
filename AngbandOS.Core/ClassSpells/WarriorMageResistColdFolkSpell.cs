internal class WarriorMageResistColdFolkSpell : ClassSpell
{
    private WarriorMageResistColdFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellResistCold);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 14;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}