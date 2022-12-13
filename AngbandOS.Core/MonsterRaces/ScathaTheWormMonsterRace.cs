using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class ScathaTheWormMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheColdMonsterSpell(),
            new CauseCriticalWoundsMonsterSpell(),
            new ConfuseMonsterSpell());
        public override char Character => 'D';
        public override Colour Colour => Colour.BrightPink;
        public override string Name => "Scatha the Worm";

        public override int ArmourClass => 130;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 10),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 10),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 10),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 6, 14)
        };
        public override bool BashDoor => true;
        public override string Description => "An ancient and wise Dragon. Scatha has grown clever over the long years. His scales are covered with frost, and his breath sends a shower of ice into the air.";
        public override bool Dragon => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Scatha the Worm";
        public override int Hdice => 20;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 44;
        public override bool Male => true;
        public override int Mexp => 17000;
        public override bool MoveBody => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override int Sleep => 70;
        public override int Speed => 120;
        public override string SplitName1 => "   Scatha   ";
        public override string SplitName2 => "    the     ";
        public override string SplitName3 => "    Worm    ";
        public override bool Unique => true;
    }
}
