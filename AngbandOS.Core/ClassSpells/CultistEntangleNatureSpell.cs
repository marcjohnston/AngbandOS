[Serializable]
internal class CultistEntangleNatureSpell : ClassSpell
{
    private CultistEntangleNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellEntangle);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 15;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 7;
}