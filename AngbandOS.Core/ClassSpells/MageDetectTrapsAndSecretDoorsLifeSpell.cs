internal class MageDetectTrapsAndSecretDoorsLifeSpell : ClassSpell
{
    private MageDetectTrapsAndSecretDoorsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDetectTrapsAndSecretDoors);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 8;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 4;
}