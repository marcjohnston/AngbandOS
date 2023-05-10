internal class WarriorMageResistanceTrueNatureSpell : ClassSpell
{
    private WarriorMageResistanceTrueNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellResistanceTrue);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 22;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 60;
}