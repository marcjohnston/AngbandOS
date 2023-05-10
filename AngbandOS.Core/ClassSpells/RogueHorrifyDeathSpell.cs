internal class RogueHorrifyDeathSpell : ClassSpell
{
    private RogueHorrifyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellHorrify);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 17;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 1;
}