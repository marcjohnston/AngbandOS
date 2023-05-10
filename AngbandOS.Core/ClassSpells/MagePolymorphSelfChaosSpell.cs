[Serializable]
internal class MagePolymorphSelfChaosSpell : ClassSpell
{
    private MagePolymorphSelfChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellPolymorphSelf);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 50;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 250;
}