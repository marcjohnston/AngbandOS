internal class RangerWhirlwindAttackNatureSpell : ClassSpell
{
    private RangerWhirlwindAttackNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellWhirlwindAttack);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 26;
    public override int ManaCost => 26;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 100;
}