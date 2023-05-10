[Serializable]
internal class DruidBlizzardNatureSpell : ClassSpell
{
    private DruidBlizzardNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellBlizzard);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 22;
    public override int ManaCost => 22;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 29;
}