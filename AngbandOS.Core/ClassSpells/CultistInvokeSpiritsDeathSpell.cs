[Serializable]
internal class CultistInvokeSpiritsDeathSpell : ClassSpell
{
    private CultistInvokeSpiritsDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellInvokeSpirits);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 18;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 30;
}