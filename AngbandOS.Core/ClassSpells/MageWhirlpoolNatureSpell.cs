[Serializable]
internal class MageWhirlpoolNatureSpell : ClassSpell
{
    private MageWhirlpoolNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellWhirlpool);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 30;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 65;
}