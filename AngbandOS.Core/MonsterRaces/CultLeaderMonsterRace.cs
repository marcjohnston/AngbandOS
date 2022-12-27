using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class CultLeaderMonsterRace : MonsterRace
    {
        protected CultLeaderMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlindnessMonsterSpell(),
            new CauseCriticalWoundsMonsterSpell(),
            new ConfuseMonsterSpell(),
            new HoldMonsterSpell(),
            new HealMonsterSpell(),
            new SummonCthuloidMonsterSpell(),
            new SummonMonsterMonsterSpell(),
            new SummonUndeadMonsterSpell());
        public override char Character => 'p';
        public override Colour Colour => Colour.BrightTurquoise;
        public override string Name => "Cult leader";

        public override int ArmourClass => 60;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 4),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 4),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 5),
        };
        public override bool BashDoor => true;
        public override string Description => "An evil priest, dressed all in black. Deadly spells hit you at an alarming rate as his black spiked mace rains down Attack after Attack on your pitiful frame.";
        public override bool Drop_2D2 => true;
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Cult leader";
        public override int Hdice => 52;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 40;
        public override bool Male => true;
        public override int Mexp => 1800;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Cult    ";
        public override string SplitName3 => "   leader   ";
    }
}
