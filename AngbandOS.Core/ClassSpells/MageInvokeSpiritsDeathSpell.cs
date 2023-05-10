[Serializable]
internal class MageInvokeSpiritsDeathSpell : ClassSpell
{
    private MageInvokeSpiritsDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellInvokeSpirits);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 15;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 30;
}