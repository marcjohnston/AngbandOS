[Serializable]
internal class PriestSummonDemonChaosSpell : ClassSpell
{
    private PriestSummonDemonChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellSummonDemon);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 49;
    public override int ManaCost => 100;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 250;
}