[Serializable]
internal class RogueDetectUnlifeDeathSpell : ClassSpell
{
    private RogueDetectUnlifeDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDetectUnlife);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 3;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 1;
}