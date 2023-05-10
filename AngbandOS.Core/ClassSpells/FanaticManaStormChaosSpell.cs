[Serializable]
internal class FanaticManaStormChaosSpell : ClassSpell
{
    private FanaticManaStormChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellManaStorm);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 48;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 200;
}