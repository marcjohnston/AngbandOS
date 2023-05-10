[Serializable]
internal class HighMagePolymorphSelfChaosSpell : ClassSpell
{
    private HighMagePolymorphSelfChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellPolymorphSelf);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 39;
    public override int ManaCost => 40;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 250;
}