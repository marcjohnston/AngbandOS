internal class PriestWhirlpoolNatureSpell : ClassSpell
{
    private PriestWhirlpoolNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellWhirlpool);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 37;
    public override int ManaCost => 32;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 65;
}