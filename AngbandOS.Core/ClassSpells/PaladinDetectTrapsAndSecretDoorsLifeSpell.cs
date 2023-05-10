internal class PaladinDetectTrapsAndSecretDoorsLifeSpell : ClassSpell
{
    private PaladinDetectTrapsAndSecretDoorsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDetectTrapsAndSecretDoors);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 5;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 4;
}