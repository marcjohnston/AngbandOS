[Serializable]
internal class RangerTeleportLevelFolkSpell : ClassSpell
{
    private RangerTeleportLevelFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellTeleportLevel);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 38;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 25;
}