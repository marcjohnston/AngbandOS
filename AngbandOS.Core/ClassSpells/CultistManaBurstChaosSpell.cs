[Serializable]
internal class CultistManaBurstChaosSpell : ClassSpell
{
    private CultistManaBurstChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellManaBurst);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 4;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 1;
}