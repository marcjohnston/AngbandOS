internal class RogueStinkingCloudDeathSpell : ClassSpell
{
    private RogueStinkingCloudDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellStinkingCloud);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 7;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 1;
}