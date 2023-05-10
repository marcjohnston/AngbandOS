[Serializable]
internal class DruidCureWoundsAndPoisonNatureSpell : ClassSpell
{
    private DruidCureWoundsAndPoisonNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellCureWoundsAndPoison);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 4;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 4;
}