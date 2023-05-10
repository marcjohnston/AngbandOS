[Serializable]
internal class CultistDetectTrapsAndSecretDoorsLifeSpell : ClassSpell
{
    private CultistDetectTrapsAndSecretDoorsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDetectTrapsAndSecretDoors);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 9;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 4;
}