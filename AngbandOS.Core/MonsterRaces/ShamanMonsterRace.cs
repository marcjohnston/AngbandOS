using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class ShamanMonsterRace : MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Shaman";

        public override int ArmourClass => 10;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 4),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 4),
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool Blink => true;
        public override string Description => "A man with powerful spirit friends...";
        public override bool Drop_1D2 => true;
        public override bool FireBolt => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Shaman";
        public override bool Haste => true;
        public override int Hdice => 12;
        public override bool Hold => true;
        public override int Hside => 12;
        public override bool ImmuneFear => true;
        public override int LevelFound => 13;
        public override bool LightningBolt => true;
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
        public override string SplitName3 => "   Shaman   ";
    }
}