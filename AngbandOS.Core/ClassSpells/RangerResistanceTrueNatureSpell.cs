internal class RangerResistanceTrueNatureSpell : ClassSpell
{
    private RangerResistanceTrueNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellResistanceTrue);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 30;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 70;
}