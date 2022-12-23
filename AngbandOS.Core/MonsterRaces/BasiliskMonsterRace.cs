using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BasiliskMonsterRace : MonsterRace
    {
        protected BasiliskMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreathePoisonMonsterSpell());
        public override char Character => 'R';
        public override Colour Colour => Colour.Black;
        public override string Name => "Basilisk";

        public override bool Animal => true;
        public override int ArmourClass => 90;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Gaze, new ParalyzeAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12)
        };
        public override bool BashDoor => true;
        public override string Description => "An evil reptile whose eyes stare deeply at you and your soul starts to wilt!";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Basilisk";
        public override int Hdice => 20;
        public override int Hside => 30;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 28;
        public override int Mexp => 350;
        public override int NoticeRange => 15;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 30;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Basilisk  ";
    }
}
