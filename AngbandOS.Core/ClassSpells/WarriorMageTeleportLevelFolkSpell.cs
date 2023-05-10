internal class WarriorMageTeleportLevelFolkSpell : ClassSpell
{
    private WarriorMageTeleportLevelFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellTeleportLevel);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 39;
    public override int ManaCost => 38;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 25;
}