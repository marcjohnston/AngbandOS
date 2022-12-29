using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class IpsissimusMonsterRace : MonsterRace
    {
        protected IpsissimusMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlindnessMonsterSpell(),
            new CauseCriticalWoundsMonsterSpell(),
            new HoldMonsterSpell(),
            new MindBlastMonsterSpell(),
            new NetherBoltMonsterSpell(),
            new ScareMonsterSpell(),
            new ForgetMonsterSpell(),
            new HasteMonsterSpell(),
            new SummonDemonMonsterSpell(),
            new SummonUndeadMonsterSpell(),
            new TeleportToMonsterSpell(),
            new TeleportSelfMonsterSpell());
        public override char Character => 'p';
        public override Colour Colour => Colour.Red;
        public override string Name => "Ipsissimus";

        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 6),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "A gaunt figure, clothed in black robes.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Ipsissimus";
        public override int Hdice => 28;
        public override int Hside => 10;
        public override int LevelFound => 36;
        public override bool Male => true;
        public override int Mexp => 666;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Ipsissimus ";
    }
}
