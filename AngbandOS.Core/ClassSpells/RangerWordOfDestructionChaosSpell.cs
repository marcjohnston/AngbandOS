[Serializable]
internal class RangerWordOfDestructionChaosSpell : ClassSpell
{
    private RangerWordOfDestructionChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellWordOfDestruction);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 43;
    public override int ManaCost => 30;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 15;
}