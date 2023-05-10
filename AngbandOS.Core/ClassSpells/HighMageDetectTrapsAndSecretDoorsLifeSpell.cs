[Serializable]
internal class HighMageDetectTrapsAndSecretDoorsLifeSpell : ClassSpell
{
    private HighMageDetectTrapsAndSecretDoorsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDetectTrapsAndSecretDoors);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 5;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}