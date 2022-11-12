using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class FormlessSpawnOfTsathogguaMonsterRace : MonsterRace
    {
        public override char Character => 'A';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Formless spawn of Tsathoggua";

        public override bool AcidBolt => true;
        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new AcidAttackEffect(), 2, 4),
            new MonsterAttack(AttackType.Hit, new AcidAttackEffect(), 2, 4),
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 3, 4),
            new MonsterAttack(AttackType.Bite, new AcidAttackEffect(), 6, 6)
        };
        public override bool BashDoor => true;
        public override bool Cthuloid => true;
        public override bool Darkness => true;
        public override string Description => "A black, protean being of amorphous slime.";
        public override bool Drop90 => true;
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override bool FireBolt => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Formless spawn of Tsathoggua";
        public override int Hdice => 22;
        public override int Hside => 20;
        public override bool HurtByFire => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 41;
        public override int Mexp => 1850;
        public override bool MindBlast => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override bool Regenerate => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 80;
        public override int Speed => 110;
        public override string SplitName1 => "  Formless  ";
        public override string SplitName2 => "  spawn of  ";
        public override string SplitName3 => " Tsathoggua ";
        public override bool SummonCthuloid => true;
    }
}
