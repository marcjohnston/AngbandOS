internal class RangerStoneToMudNatureSpell : ClassSpell
{
    private RangerStoneToMudNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellStoneToMud);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 7;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 4;
}