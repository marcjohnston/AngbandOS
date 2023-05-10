[Serializable]
internal class CultistPolymorphSelfChaosSpell : ClassSpell
{
    private CultistPolymorphSelfChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellPolymorphSelf);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 39;
    public override int ManaCost => 40;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 250;
}