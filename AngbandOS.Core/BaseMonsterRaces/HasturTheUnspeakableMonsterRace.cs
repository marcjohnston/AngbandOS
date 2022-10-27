using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class HasturTheUnspeakableMonsterRace : MonsterRace
    {
        public override char Character => 'X';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Hastur the Unspeakable";

        public override int ArmourClass => 150;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 14, 8),
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 14, 8),
            new MonsterAttack(AttackType.Bite, new Exp80AttackEffect(), 6, 6),
            new MonsterAttack(AttackType.Bite, new Exp80AttackEffect(), 6, 6)
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BrainSmash => true;
        public override bool BreatheDark => true;
        public override bool BreatheNether => true;
        public override bool CauseMortalWounds => true;
        public override bool ColdBlood => true;
        public override string Description => "Its form is partially that of a reptile, partially that of a gigantic octopus. It will destroy you.";
        public override bool DrainMana => true;
        public override bool Drop_2D2 => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Hastur the Unspeakable";
        public override bool GreatOldOne => true;
        public override bool Haste => true;
        public override int Hdice => 55;
        public override bool Heal => true;
        public override bool Hold => true;
        public override int Hside => 95;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 55;
        public override bool LightningAura => true;
        public override int Mexp => 23000;
        public override bool Nonliving => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 4;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "   Hastur   ";
        public override string SplitName2 => "    the     ";
        public override string SplitName3 => "Unspeakable ";
        public override bool SummonCthuloid => true;
        public override bool TeleportAway => true;
        public override bool TeleportSelf => true;
        public override bool TeleportTo => true;
        public override bool Unique => true;
        public override bool WaterBall => true;
    }
}
