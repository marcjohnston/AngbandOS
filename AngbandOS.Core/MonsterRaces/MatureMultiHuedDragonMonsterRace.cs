using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class MatureMultiHuedDragonMonsterRace : MonsterRace
    {
        public override char Character => 'd';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Mature multi-hued dragon";

        public override int ArmourClass => 65;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 10),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 10),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
        };
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BreatheAcid => true;
        public override bool BreatheCold => true;
        public override bool BreatheFire => true;
        public override bool BreatheLightning => true;
        public override bool BreathePoison => true;
        public override bool Confuse => true;
        public override string Description => "A large dragon, scales shimmering many colours.";
        public override bool Dragon => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Mature multi-hued dragon";
        public override int Hdice => 64;
        public override int Hside => 10;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 38;
        public override int Mexp => 1700;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override bool Scare => true;
        public override int Sleep => 50;
        public override int Speed => 110;
        public override string SplitName1 => "   Mature   ";
        public override string SplitName2 => " multi-hued ";
        public override string SplitName3 => "   dragon   ";
    }
}
