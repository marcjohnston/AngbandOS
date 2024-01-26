// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GreenNagaMonsterRace : MonsterRace
{
    protected GreenNagaMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerNSymbol));
    public override ColorEnum Color => ColorEnum.Green;
    public override string Name => "Green naga";

    public override int ArmorClass => 40;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(CrushAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 8),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(SpitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(AcidAttackEffect)), 2, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "A large green serpent with a female's torso. Her green skin glistens with acid.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override bool Female => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Green naga";
    public override int Hdice => 9;
    public override int Hside => 8;
    public override bool ImmuneAcid => true;
    public override int LevelFound => 5;
    public override int Mexp => 30;
    public override int NoticeRange => 18;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 120;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Green    ";
    public override string SplitName3 => "    naga    ";
    public override bool TakeItem => true;
}
