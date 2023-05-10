[Serializable]
internal class DruidFirstAidNatureSpell : ClassSpell
{
    private DruidFirstAidNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellFirstAid);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 1;
    public override int BaseFailure => 15;
    public override int FirstCastExperience => 3;
}