// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ColdHoundMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.ColdBreatheBallMonsterSpell)
    };

    public override string SymbolName => nameof(UpperZSymbol);
    
    public override bool Animal => true;
    public override int ArmorClass => 30;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.ColdAttackEffect), 1, 6),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 8),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "A hound as tall as a man, this creature appears to be composed of angular planes of ice. Cold radiates from it and freezes your breath in the air.";
    public override bool ForceSleep => true;
    public override int FreqInate => 10;
    public override int FreqSpell => 10;
    public override string FriendlyName => "Cold hound";
    public override bool Friends => true;
    public override int Hdice => 10;
    public override int Hside => 6;
    public override bool ImmuneCold => true;
    public override int LevelFound => 18;
    public override int Mexp => 70;
    public override int NoticeRange => 30;
    public override int Rarity => 1;
    public override int Sleep => 0;
    public override int Speed => 110;
    public override string? MultilineName => "Cold\nhound";
}
