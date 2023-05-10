[Serializable]
internal class RangerInvokeSpiritsDeathSpell : ClassSpell
{
    private RangerInvokeSpiritsDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellInvokeSpirits);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 25;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 100;
}