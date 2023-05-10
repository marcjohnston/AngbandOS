[Serializable]
internal class WarriorMageAstralLoreTarotSpell : ClassSpell
{
    private WarriorMageAstralLoreTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellAstralLore);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 60;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 100;
}