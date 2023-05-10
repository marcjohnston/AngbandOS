[Serializable]
internal class CultistPolymorphOtherChaosSpell : ClassSpell
{
    private CultistPolymorphOtherChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellPolymorphOther);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 5;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 9;
}