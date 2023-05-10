[Serializable]
internal class CultistWordOfDestructionChaosSpell : ClassSpell
{
    private CultistWordOfDestructionChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellWordOfDestruction);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 27;
    public override int ManaCost => 17;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 15;
}