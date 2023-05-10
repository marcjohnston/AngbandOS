internal class RoguePhantasmalServantTarotSpell : ClassSpell
{
    private RoguePhantasmalServantTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellPhantasmalServant);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 26;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 8;
}