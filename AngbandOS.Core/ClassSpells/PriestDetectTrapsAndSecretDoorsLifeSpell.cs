internal class PriestDetectTrapsAndSecretDoorsLifeSpell : ClassSpell
{
    private PriestDetectTrapsAndSecretDoorsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDetectTrapsAndSecretDoors);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 4;
    public override int BaseFailure => 28;
    public override int FirstCastExperience => 2;
}