[Serializable]
internal class CultistAlterRealityChaosSpell : ClassSpell
{
    private CultistAlterRealityChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellAlterReality);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 26;
    public override int ManaCost => 22;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 150;
}