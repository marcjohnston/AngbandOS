[Serializable]
internal class DruidStoneTellNatureSpell : ClassSpell
{
    private DruidStoneTellNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellStoneTell);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 35;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 200;
}