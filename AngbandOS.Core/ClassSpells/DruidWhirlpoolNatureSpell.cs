[Serializable]
internal class DruidWhirlpoolNatureSpell : ClassSpell
{
    private DruidWhirlpoolNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellWhirlpool);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 32;
    public override int ManaCost => 28;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 65;
}