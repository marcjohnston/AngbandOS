[Serializable]
internal class RangerNaturesWrathNatureSpell : ClassSpell
{
    private RangerNaturesWrathNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellNaturesWrath);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 41;
    public override int ManaCost => 80;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 250;
}