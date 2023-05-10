internal class PaladinInvokeSpiritsDeathSpell : ClassSpell
{
    private PaladinInvokeSpiritsDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellInvokeSpirits);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 20;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 30;
}