[Serializable]
internal class CultistChaosBoltChaosSpell : ClassSpell
{
    private CultistChaosBoltChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellChaosBolt);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 10;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 9;
}