internal class CultistPhantasmalServantTarotSpell : ClassSpell
{
    private CultistPhantasmalServantTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellPhantasmalServant);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 31;
    public override int ManaCost => 26;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 8;
}