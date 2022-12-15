using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BoldorKingOfTheYeeksMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlindnessMonsterSpell(),
            new SlowMonsterSpell(),
            new BlinkMonsterSpell(),
            new HealMonsterSpell(),
            new SummonKinMonsterSpell(),
            new TeleportSelfMonsterSpell());
        public override char Character => 'y';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Boldor, King of the Yeeks";

        public override bool Animal => true;
        public override int ArmourClass => 24;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 9),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 9),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 8),
        };
        public override bool BashDoor => true;
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
        public override int Hside => 10;
        public override bool ImmuneAcid => true;
        public override int LevelFound => 13;
        public override bool Male => true;
        public override int Mexp => 200;
        public override int NoticeRange => 18;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Boldor   ";
        public override bool Unique => true;
    }
}
