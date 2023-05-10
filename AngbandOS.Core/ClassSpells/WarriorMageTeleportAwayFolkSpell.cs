internal class WarriorMageTeleportAwayFolkSpell : ClassSpell
{
    private WarriorMageTeleportAwayFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellTeleportAway);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 43;
    public override int ManaCost => 42;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 25;
}