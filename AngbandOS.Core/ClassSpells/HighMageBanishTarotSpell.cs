internal class HighMageBanishTarotSpell : ClassSpell
{
    private HighMageBanishTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellBanish);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 39;
    public override int ManaCost => 36;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 12;
}