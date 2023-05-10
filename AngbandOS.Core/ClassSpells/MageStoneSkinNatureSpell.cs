[Serializable]
internal class MageStoneSkinNatureSpell : ClassSpell
{
    private MageStoneSkinNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellStoneSkin);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 12;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 120;
}