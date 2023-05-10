[Serializable]
internal class WarriorMageWhirlwindAttackNatureSpell : ClassSpell
{
    private WarriorMageWhirlwindAttackNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellWhirlwindAttack);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 27;
    public override int ManaCost => 27;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 25;
}