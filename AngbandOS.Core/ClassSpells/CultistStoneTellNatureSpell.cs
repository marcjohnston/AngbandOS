internal class CultistStoneTellNatureSpell : ClassSpell
{
    private CultistStoneTellNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellStoneTell);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 42;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 200;
}