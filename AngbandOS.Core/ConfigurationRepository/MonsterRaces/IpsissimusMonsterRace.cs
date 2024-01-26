// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class IpsissimusMonsterRace : MonsterRace
{
    protected IpsissimusMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BlindnessMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(CauseCriticalWoundsMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(HoldMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(MindBlastMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(NetherBoltMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(ScareMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(ForgetMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(HasteMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(SummonDemonMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(SummonUndeadMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(TeleportToMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(TeleportSelfMonsterSpell)));
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerPSymbol));
    public override ColorEnum Color => ColorEnum.Red;
    public override string Name => "Ipsissimus";

    public override int ArmorClass => 50;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(HitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 2, 6),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(HitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 2, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "A gaunt figure, clothed in black robes.";
    public override bool Drop_1D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Ipsissimus";
    public override int Hdice => 28;
    public override int Hside => 10;
    public override int LevelFound => 36;
    public override bool Male => true;
    public override int Mexp => 666;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => " Ipsissimus ";
}
