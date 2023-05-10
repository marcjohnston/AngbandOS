internal class RogueMaledictionDeathSpell : ClassSpell
{
    private RogueMaledictionDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellMalediction);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 4;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 1;
}