internal class CultistTeleportAwayFolkSpell : ClassSpell
{
    private CultistTeleportAwayFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellTeleportAway);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 43;
    public override int ManaCost => 42;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 25;
}