[Serializable]
internal class PriestResistanceTrueNatureSpell : ClassSpell
{
    private PriestResistanceTrueNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellResistanceTrue);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 18;
    public override int ManaCost => 20;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 60;
}