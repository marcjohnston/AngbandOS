[Serializable]
internal class RangerProtectFromCorrosionNatureSpell : ClassSpell
{
    private RangerProtectFromCorrosionNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellProtectFromCorrosion);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 80;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 250;
}