[Serializable]
internal class CultistInvokeChaosChaosSpell : ClassSpell
{
    private CultistInvokeChaosChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellInvokeChaos);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 35;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 40;
}