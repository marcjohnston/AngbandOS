[Serializable]
internal class RogueTeleportFolkSpell : ClassSpell
{
    private RogueTeleportFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellTeleport);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 22;
    public override int ManaCost => 20;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 8;
}