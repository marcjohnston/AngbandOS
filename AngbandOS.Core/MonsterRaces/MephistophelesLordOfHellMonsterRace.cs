using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class MephistophelesLordOfHellMonsterRace : MonsterRace
    {
        public override char Character => 'U';
        public override Colour Colour => Colour.Red;
        public override string Name => "Mephistopheles, Lord of Hell";

        public override int ArmourClass => 150;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Gaze, new Exp80AttackEffect(), 1, 5),
            new MonsterAttack(AttackType.Gaze, new TerrifyAttackEffect(), 1, 5),
            new MonsterAttack(AttackType.Touch, new FireAttackEffect(), 4, 5),
            new MonsterAttack(AttackType.Touch, new UnPowerAttackEffect(), 4, 5)
        };
        public override bool BashDoor => true;
        public override bool BrainSmash => true;
        public override bool BreatheFire => true;
        public override bool BreatheNether => true;
        public override bool Demon => true;
        public override string Description => "A duke of hell, in the flesh.";
        public override bool DreadCurse => true;
        public override bool Drop_2D2 => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool EscortsGroup => true;
        public override bool Evil => true;
        public override bool FireAura => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Mephistopheles, Lord of Hell";
        public override int Hdice => 30;
        public override bool Hold => true;
        public override int Hside => 222;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 84;
        public override bool Male => true;
        public override int Mexp => 42500;
        public override bool MoveBody => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override bool ResistNether => true;
        public override bool ResistPlasma => true;
        public override bool Scare => true;
        public override int Sleep => 50;
        public override int Speed => 140;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "Mephistophel";
        public override bool SummonDemon => true;
        public override bool SummonHiUndead => true;
        public override bool SummonReaver => true;
        public override bool SummonUndead => true;
        public override bool TeleportTo => true;
        public override bool Unique => true;
    }
}