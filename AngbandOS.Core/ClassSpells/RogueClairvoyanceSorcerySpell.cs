internal class RogueClairvoyanceSorcerySpell : ClassSpell
{
    private RogueClairvoyanceSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellClairvoyance);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 37;
    public override int ManaCost => 40;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 100;
}