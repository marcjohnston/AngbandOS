[Serializable]
internal class WarriorMagePolymorphSelfChaosSpell : ClassSpell
{
    private WarriorMagePolymorphSelfChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellPolymorphSelf);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 55;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 250;
}