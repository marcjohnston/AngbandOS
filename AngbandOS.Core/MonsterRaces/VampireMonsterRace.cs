using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class VampireMonsterRace : MonsterRace
    {
        public override char Character => 'V';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Vampire";

        public override int ArmourClass => 45;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Bite, new Exp20AttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Bite, new Exp20AttackEffect(), 1, 4)
        };
        public override bool BashDoor => true;
        public override bool CauseSeriousWounds => true;
        public override bool ColdBlood => true;
        public override bool Darkness => true;
        public override string Description => "It is a humanoid with an aura of power. You notice a sharp set of front teeth.";
        public override bool Drop_1D2 => true;
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Vampire";
        public override int Hdice => 25;
        public override bool Hold => true;
        public override int Hside => 12;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 27;
        public override int Mexp => 175;
        public override bool MindBlast => true;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override bool Regenerate => true;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Vampire   ";
        public override bool TeleportTo => true;
        public override bool Undead => true;
    }
}