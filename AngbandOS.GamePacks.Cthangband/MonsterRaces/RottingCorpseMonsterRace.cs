// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RottingCorpseMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerZSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    
    public override int ArmorClass => 20;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 1, 3),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 1, 3),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "Corpses awakened from their sleep by dark sorceries. ";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Rotting corpse";
    public override bool Friends => true;
    public override int Hdice => 8;
    public override int Hside => 8;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 7;
    public override int Mexp => 15;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string? MultilineName => "Rotting\ncorpse";
    public override bool Undead => true;
}
