internal class RangerEntangleNatureSpell : ClassSpell
{
    private RangerEntangleNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellEntangle);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 18;
    public override int ManaCost => 20;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 8;
}