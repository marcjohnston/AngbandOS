[Serializable]
internal class CultistSonicBoomChaosSpell : ClassSpell
{
    private CultistSonicBoomChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellSonicBoom);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 11;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 10;
}