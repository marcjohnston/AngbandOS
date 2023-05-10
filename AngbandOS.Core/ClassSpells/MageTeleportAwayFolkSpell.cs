[Serializable]
internal class MageTeleportAwayFolkSpell : ClassSpell
{
    private MageTeleportAwayFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellTeleportAway);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 30;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 25;
}