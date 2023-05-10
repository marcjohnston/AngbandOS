[Serializable]
internal class DruidProtectFromCorrosionNatureSpell : ClassSpell
{
    private DruidProtectFromCorrosionNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellProtectFromCorrosion);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 37;
    public override int ManaCost => 65;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 250;
}