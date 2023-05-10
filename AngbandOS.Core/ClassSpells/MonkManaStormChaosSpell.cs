[Serializable]
internal class MonkManaStormChaosSpell : ClassSpell
{
    private MonkManaStormChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellManaStorm);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 49;
    public override int ManaCost => 50;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 200;
}