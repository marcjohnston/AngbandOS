[Serializable]
internal class PriestTeleportLevelFolkSpell : ClassSpell
{
    private PriestTeleportLevelFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellTeleportLevel);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 37;
    public override int ManaCost => 36;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 25;
}