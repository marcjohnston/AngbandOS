// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WerewormMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerWSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    
    public override bool Animal => true;
    public override int ArmorClass => 70;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(GazeAttack), nameof(AttackEffectsEnum.Exp20AttackEffect), 0, 0),
        (nameof(CrawlAttack), nameof(AttackEffectsEnum.AcidAttackEffect), 2, 4),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 10),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 1, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "A huge wormlike shape dripping acid, twisted by evil sorcery into a foul monster that breeds on death.";
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Wereworm";
    public override int Hdice => 100;
    public override int Hside => 11;
    public override bool ImmuneAcid => true;
    public override int LevelFound => 25;
    public override int Mexp => 300;
    public override int NoticeRange => 15;
    public override int Rarity => 3;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string? MultilineName => "Wereworm";
}
