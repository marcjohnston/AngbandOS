internal class RogueRechargingSorcerySpell : ClassSpell
{
    private RogueRechargingSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellRecharging);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 21;
    public override int ManaCost => 12;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 1;
}