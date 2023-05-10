internal class RangerStoneSkinNatureSpell : ClassSpell
{
    private RangerStoneSkinNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellStoneSkin);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 15;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 60;
}