internal class HighMageTeleportAwayFolkSpell : ClassSpell
{
    private HighMageTeleportAwayFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellTeleportAway);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 28;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 25;
}