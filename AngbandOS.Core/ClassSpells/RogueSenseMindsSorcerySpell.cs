internal class RogueSenseMindsSorcerySpell : ClassSpell
{
    private RogueSenseMindsSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellSenseMinds);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 16;
    public override int ManaCost => 10;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 10;
}