[Serializable]
internal class MageWhirlwindAttackNatureSpell : ClassSpell
{
    private MageWhirlwindAttackNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellWhirlwindAttack);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 23;
    public override int ManaCost => 23;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 50;
}