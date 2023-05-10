[Serializable]
internal class CultistNaturesWrathNatureSpell : ClassSpell
{
    private CultistNaturesWrathNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellNaturesWrath);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 95;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 250;
}