internal class PriestStoneTellNatureSpell : ClassSpell
{
    private PriestStoneTellNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellStoneTell);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 39;
    public override int ManaCost => 40;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 200;
}