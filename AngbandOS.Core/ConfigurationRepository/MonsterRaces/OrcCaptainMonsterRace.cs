// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class OrcCaptainMonsterRace : MonsterRace
{
    protected OrcCaptainMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<Arrow1D6MonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerOSymbol>();
    public override ColourEnum Colour => ColourEnum.Green;
    public override string Name => "Orc captain";

    public override int ArmourClass => 59;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 3, 4),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 3, 4),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 3, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "An armoured orc with an air of authority.";
    public override bool Drop90 => true;
    public override bool Escorted => true;
    public override bool Evil => true;
    public override int FreqInate => 16;
    public override int FreqSpell => 16;
    public override string FriendlyName => "Orc captain";
    public override int Hdice => 20;
    public override int Hside => 10;
    public override int LevelFound => 16;
    public override bool Male => true;
    public override int Mexp => 40;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override bool Orc => true;
    public override int Rarity => 3;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    Orc     ";
    public override string SplitName3 => "  captain   ";
}