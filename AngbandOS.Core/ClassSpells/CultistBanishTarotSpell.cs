internal class CultistBanishTarotSpell : ClassSpell
{
    private CultistBanishTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellBanish);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 46;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 12;
}