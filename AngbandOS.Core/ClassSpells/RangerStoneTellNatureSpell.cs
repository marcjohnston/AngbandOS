[Serializable]
internal class RangerStoneTellNatureSpell : ClassSpell
{
    private RangerStoneTellNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellStoneTell);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 40;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 200;
}