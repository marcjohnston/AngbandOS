using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GlaurungFatherOfTheDragonsMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheFireMonsterSpell(),
            new CauseCriticalWoundsMonsterSpell(),
            new ConfuseMonsterSpell(),
            new SummonDragonMonsterSpell());
        public override char Character => 'D';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Glaurung, Father of the Dragons";

        public override int ArmourClass => 120;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 7, 12),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 7, 12),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 8, 14),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 8, 14)
        };
        public override bool BashDoor => true;
        public override string Description => "Glaurung is the father of all dragons, and was for a long time the most powerful. Nevertheless, he still has full command over his brood and can command them to appear whenever he so wishes. He is the definition of dragonfire.";
        public override bool Dragon => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Glaurung, Father of the Dragons";
        public override int Hdice => 28;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 48;
        public override bool Male => true;
        public override int Mexp => 25000;
        public override bool MoveBody => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override int Sleep => 70;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Glaurung  ";
        public override bool Unique => true;
    }
}
