internal class HighMageTeleportAwayTarotSpell : ClassSpell
{
    private HighMageTeleportAwayTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTeleportAway);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 12;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}