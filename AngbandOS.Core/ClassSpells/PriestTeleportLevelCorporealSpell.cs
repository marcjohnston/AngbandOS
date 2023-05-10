internal class PriestTeleportLevelCorporealSpell : ClassSpell
{
    private PriestTeleportLevelCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellTeleportLevel);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 22;
    public override int ManaCost => 22;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 25;
}