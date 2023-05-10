internal class MageResistanceTrueNatureSpell : ClassSpell
{
    private MageResistanceTrueNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellResistanceTrue);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 20;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 60;
}