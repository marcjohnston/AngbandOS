[Serializable]
internal class MageStoneTellNatureSpell : ClassSpell
{
    private MageStoneTellNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellStoneTell);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 37;
    public override int ManaCost => 40;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 200;
}