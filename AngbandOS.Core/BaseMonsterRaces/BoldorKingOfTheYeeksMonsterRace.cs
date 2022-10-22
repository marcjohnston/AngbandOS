using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class BoldorKingOfTheYeeksMonsterRace : Base2MonsterRace
    {
        public override char Character => 'y';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Boldor, King of the Yeeks";

        public override bool Animal => true;
        public override int ArmourClass => 24;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 9;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 9;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 8;
        public override BaseAttackEffect? Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool Blink => true;
        public override string Description => "A great yeek, powerful in magic and sorcery, but a yeek all the same.";
        public override bool Drop_1D2 => true;
        public override bool Drop90 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool EscortsGroup => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Boldor, King of the Yeeks";
        public override int Hdice => 18;
        public override bool Heal => true;
        public override int Hside => 10;
        public override bool ImmuneAcid => true;
        public override int Level => 13;
        public override bool Male => true;
        public override int Mexp => 200;
        public override int NoticeRange => 18;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override bool Slow => true;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Boldor   ";
        public override bool SummonKin => true;
        public override bool TeleportSelf => true;
        public override bool Unique => true;
    }
}
