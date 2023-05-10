internal class DruidLightningBoltNatureSpell : ClassSpell
{
    private DruidLightningBoltNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellLightningBolt);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 4;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 6;
}