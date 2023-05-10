[Serializable]
internal class CultistSummonDemonChaosSpell : ClassSpell
{
    private CultistSummonDemonChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellSummonDemon);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 44;
    public override int ManaCost => 90;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 250;
}