internal class DruidFrostBoltNatureSpell : ClassSpell
{
    private DruidFrostBoltNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellFrostBolt);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 5;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 6;
}