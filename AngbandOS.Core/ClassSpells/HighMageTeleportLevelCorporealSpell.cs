internal class HighMageTeleportLevelCorporealSpell : ClassSpell
{
    private HighMageTeleportLevelCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellTeleportLevel);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 12;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 25;
}