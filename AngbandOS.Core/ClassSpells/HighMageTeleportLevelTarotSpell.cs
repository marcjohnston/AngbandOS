internal class HighMageTeleportLevelTarotSpell : ClassSpell
{
    private HighMageTeleportLevelTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTeleportLevel);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 28;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 10;
}