[Serializable]
internal class RogueTeleportAwayFolkSpell : ClassSpell
{
    private RogueTeleportAwayFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellTeleportAway);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 46;
    public override int ManaCost => 40;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 25;
}