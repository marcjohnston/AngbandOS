internal class PriestTeleportFolkSpell : ClassSpell
{
    private PriestTeleportFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellTeleport);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 18;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 8;
}