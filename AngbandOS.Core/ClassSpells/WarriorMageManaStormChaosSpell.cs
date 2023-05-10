[Serializable]
internal class WarriorMageManaStormChaosSpell : ClassSpell
{
    private WarriorMageManaStormChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellManaStorm);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 49;
    public override int ManaCost => 50;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 200;
}