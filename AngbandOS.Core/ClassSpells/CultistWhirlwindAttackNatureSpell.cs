internal class CultistWhirlwindAttackNatureSpell : ClassSpell
{
    private CultistWhirlwindAttackNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellWhirlwindAttack);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 27;
    public override int ManaCost => 27;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 25;
}