internal class RogueNetherBoltDeathSpell : ClassSpell
{
    private RogueNetherBoltDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellNetherBolt);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 23;
    public override int ManaCost => 23;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 4;
}