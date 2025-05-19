// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DarkElvenWarriorMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.MagicMissileMonsterSpell)
    };

    public override string SymbolName => nameof(LowerHSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override int ArmorClass => 16;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 8),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "A dark elven figure in armor and ready with his sword.";
    public override bool Drop_1D2 => true;
    public override bool Evil => true;
    public override int FreqInate => 12;
    public override int FreqSpell => 12;
    public override string FriendlyName => "Dark elven warrior";
    public override int Hdice => 10;
    public override int Hside => 11;
    public override bool HurtByLight => true;
    public override int LevelFound => 10;
    public override bool Male => true;
    public override int Mexp => 50;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string? MultilineName => "Dark\nelven\nwarrior";
}
