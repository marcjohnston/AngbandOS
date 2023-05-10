[Serializable]
internal class PriestWhirlwindAttackNatureSpell : ClassSpell
{
    private PriestWhirlwindAttackNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellWhirlwindAttack);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 25;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 25;
}