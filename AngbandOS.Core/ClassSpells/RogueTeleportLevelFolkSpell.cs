[Serializable]
internal class RogueTeleportLevelFolkSpell : ClassSpell
{
    private RogueTeleportLevelFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellTeleportLevel);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 38;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 25;
}