[Serializable]
internal class MageEntangleNatureSpell : ClassSpell
{
    private MageEntangleNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellEntangle);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 12;
    public override int BaseFailure => 55;
    public override int FirstCastExperience => 8;
}