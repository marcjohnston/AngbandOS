[Serializable]
internal class FanaticFireBoltChaosSpell : ClassSpell
{
    private FanaticFireBoltChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFireBolt);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 7;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 5;
}