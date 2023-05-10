[Serializable]
internal class RogueOrbOfEntropyDeathSpell : ClassSpell
{
    private RogueOrbOfEntropyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellOrbOfEntropy);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 21;
    public override int ManaCost => 21;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 3;
}