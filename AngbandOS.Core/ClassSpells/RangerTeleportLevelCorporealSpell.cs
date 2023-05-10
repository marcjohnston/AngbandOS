internal class RangerTeleportLevelCorporealSpell : ClassSpell
{
    private RangerTeleportLevelCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellTeleportLevel);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 27;
    public override int ManaCost => 27;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 15;
}