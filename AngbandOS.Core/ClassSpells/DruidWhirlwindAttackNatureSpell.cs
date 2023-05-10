[Serializable]
internal class DruidWhirlwindAttackNatureSpell : ClassSpell
{
    private DruidWhirlwindAttackNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellWhirlwindAttack);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 20;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 50;
}