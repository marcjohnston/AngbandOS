[Serializable]
internal class RangerWhirlpoolNatureSpell : ClassSpell
{
    private RangerWhirlpoolNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellWhirlpool);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 36;
    public override int ManaCost => 33;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 45;
}