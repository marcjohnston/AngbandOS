// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MaulotaurMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.FireBallMonsterSpell),
        nameof(MonsterSpellsEnum.FireBoltMonsterSpell),
        nameof(MonsterSpellsEnum.PlasmaBoltMonsterSpell)
    };

    public override string SymbolName => nameof(UpperHSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    
    public override int ArmorClass => 50;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ButtAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 4, 6),
        (nameof(ButtAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 4, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.ShatterAttackEffect), 5, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.ShatterAttackEffect), 5, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "It is a belligrent minotaur with some destructive magical arsenal, armed with a hammer.";
    public override bool Drop60 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Maulotaur";
    public override int Hdice => 250;
    public override int Hside => 10;
    public override bool ImmuneFire => true;
    public override int LevelFound => 50;
    public override int Mexp => 4500;
    public override int NoticeRange => 13;
    public override bool OnlyDropItem => true;
    public override int Rarity => 2;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override int Speed => 130;
    public override string? MultilineName => "Maulotaur";
    public override bool Stupid => true;
}
