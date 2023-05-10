internal class PriestInvokeSpiritsDeathSpell : ClassSpell
{
    private PriestInvokeSpiritsDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellInvokeSpirits);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 15;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 30;
}