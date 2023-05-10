internal class RogueInvokeSpiritsDeathSpell : ClassSpell
{
    private RogueInvokeSpiritsDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellInvokeSpirits);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 23;
    public override int ManaCost => 20;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 20;
}