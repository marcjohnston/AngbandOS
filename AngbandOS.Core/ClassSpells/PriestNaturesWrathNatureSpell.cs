[Serializable]
internal class PriestNaturesWrathNatureSpell : ClassSpell
{
    private PriestNaturesWrathNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellNaturesWrath);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 90;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 200;
}