[Serializable]
internal class PriestTeleportAwayFolkSpell : ClassSpell
{
    private PriestTeleportAwayFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellTeleportAway);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 38;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 25;
}