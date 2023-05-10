internal class PriestStoneToMudNatureSpell : ClassSpell
{
    private PriestStoneToMudNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellStoneToMud);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 6;
}