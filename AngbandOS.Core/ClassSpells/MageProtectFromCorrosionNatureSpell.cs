[Serializable]
internal class MageProtectFromCorrosionNatureSpell : ClassSpell
{
    private MageProtectFromCorrosionNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellProtectFromCorrosion);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 90;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 250;
}