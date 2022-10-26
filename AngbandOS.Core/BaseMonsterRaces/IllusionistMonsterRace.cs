using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class IllusionistMonsterRace : Base2MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Pink;
        public override string Name => "Illusionist";

        public override int ArmourClass => 10;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 2),
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool Blink => true;
        public override bool Confuse => true;
        public override bool Darkness => true;
        public override string Description => "A deceptive spell caster.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Illusionist";
        public override bool Haste => true;
        public override int Hdice => 12;
        public override bool Hold => true;
        public override int Hside => 8;
        public override int Level => 13;
        public override bool Male => true;
        public override int Mexp => 50;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override bool Slow => true;
        public override bool Smart => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "Illusionist ";
        public override bool TeleportSelf => true;
    }
}
