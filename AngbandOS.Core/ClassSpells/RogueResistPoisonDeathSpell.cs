[Serializable]
internal class RogueResistPoisonDeathSpell : ClassSpell
{
    private RogueResistPoisonDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellResistPoison);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 15;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 1;
}