internal class WarriorMageResistAcidFolkSpell : ClassSpell
{
    private WarriorMageResistAcidFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellResistAcid);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 18;
    public override int ManaCost => 17;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}