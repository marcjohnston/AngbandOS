[Serializable]
internal class CultistCallChaosChaosSpell : ClassSpell
{
    private CultistCallChaosChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellCallChaos);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 36;
    public override int ManaCost => 36;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 100;
}