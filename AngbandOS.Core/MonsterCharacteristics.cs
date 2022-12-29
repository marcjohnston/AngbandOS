namespace AngbandOS.Core
{
    [Serializable]
    internal class MonsterCharacteristics : IMonsterCharacteristics
    {
        public MonsterCharacteristics()
        {
            AttrClear = false;
            AttrMulti = false;
            CharClear = false;
            CharMulti = false;
            Drop_1D2 = false;
            Drop_2D2 = false;
            Drop_3D2 = false;
            Drop_4D2 = false;
            Drop60 = false;
            Drop90 = false;
            DropGood = false;
            DropGreat = false;
            Escorted = false;
            EscortsGroup = false;
            Female = false;
            ForceMaxHp = false;
            ForceSleep = false;
            Friends = false;
            Male = false;
            NeverAttack = false;
            NeverMove = false;
            OnlyDropGold = false;
            OnlyDropItem = false;
            RandomMove25 = false;
            RandomMove50 = false;
            Unique = false;

            AttrAny = false;
            BashDoor = false;
            ColdBlood = false;
            EldritchHorror = false;
            EmptyMind = false;
            FireAura = false;
            Invisible = false;
            KillBody = false;
            KillItem = false;
            KillWall = false;
            LightningAura = false;
            MoveBody = false;
            Multiply = false;
            OpenDoor = false;
            PassWall = false;
            Powerful = false;
            Reflecting = false;
            Regenerate = false;
            Shapechanger = false;
            Smart = false;
            Stupid = false;
            TakeItem = false;
            WeirdMind = false;

            Animal = false;
            Cthuloid = false;
            Demon = false;
            Dragon = false;
            Evil = false;
            Giant = false;
            Good = false;
            GreatOldOne = false;
            HurtByCold = false;
            HurtByFire = false;
            HurtByLight = false;
            HurtByRock = false;
            ImmuneAcid = false;
            ImmuneCold = false;
            ImmuneConfusion = false;
            ImmuneFear = false;
            ImmuneFire = false;
            ImmuneLightning = false;
            ImmunePoison = false;
            ImmuneSleep = false;
            ImmuneStun = false;
            Nonliving = false;
            Orc = false;
            ResistDisenchant = false;
            ResistNether = false;
            ResistNexus = false;
            ResistPlasma = false;
            ResistTeleport = false;
            ResistWater = false;
            Troll = false;
            Undead = false;
        }

        public MonsterCharacteristics(IMonsterCharacteristics copyFrom)
        {
            AttrClear = copyFrom.AttrClear;
            AttrMulti = copyFrom.AttrMulti;
            CharClear = copyFrom.CharClear;
            CharMulti = copyFrom.CharMulti;
            Drop_1D2 = copyFrom.Drop_1D2;
            Drop_2D2 = copyFrom.Drop_2D2;
            Drop_3D2 = copyFrom.Drop_3D2;
            Drop_4D2 = copyFrom.Drop_4D2;
            Drop60 = copyFrom.Drop60;
            Drop90 = copyFrom.Drop90;
            DropGood = copyFrom.DropGood;
            DropGreat = copyFrom.DropGreat;
            Escorted = copyFrom.Escorted;
            EscortsGroup = copyFrom.EscortsGroup;
            Female = copyFrom.Female;
            ForceMaxHp = copyFrom.ForceMaxHp;
            ForceSleep = copyFrom.ForceSleep;
            Friends = copyFrom.Friends;
            Male = copyFrom.Male;
            NeverAttack = copyFrom.NeverAttack;
            NeverMove = copyFrom.NeverMove;
            OnlyDropGold = copyFrom.OnlyDropGold;
            OnlyDropItem = copyFrom.OnlyDropItem;
            RandomMove25 = copyFrom.RandomMove25;
            RandomMove50 = copyFrom.RandomMove50;
            Unique = copyFrom.Unique;
            AttrAny = copyFrom.AttrAny;
            BashDoor = copyFrom.BashDoor;
            ColdBlood = copyFrom.ColdBlood;
            EldritchHorror = copyFrom.EldritchHorror;
            EmptyMind = copyFrom.EmptyMind;
            FireAura = copyFrom.FireAura;
            Invisible = copyFrom.Invisible;
            KillBody = copyFrom.KillBody;
            KillItem = copyFrom.KillItem;
            KillWall = copyFrom.KillWall;
            LightningAura = copyFrom.LightningAura;
            MoveBody = copyFrom.MoveBody;
            Multiply = copyFrom.Multiply;
            OpenDoor = copyFrom.OpenDoor;
            PassWall = copyFrom.PassWall;
            Powerful = copyFrom.Powerful;
            Reflecting = copyFrom.Reflecting;
            Regenerate = copyFrom.Regenerate;
            Shapechanger = copyFrom.Shapechanger;
            Smart = copyFrom.Smart;
            Stupid = copyFrom.Stupid;
            TakeItem = copyFrom.TakeItem;
            WeirdMind = copyFrom.WeirdMind;
            Animal = copyFrom.Animal;
            Cthuloid = copyFrom.Cthuloid;
            Demon = copyFrom.Demon;
            Dragon = copyFrom.Dragon;
            Evil = copyFrom.Evil;
            Giant = copyFrom.Giant;
            Good = copyFrom.Good;
            GreatOldOne = copyFrom.GreatOldOne;
            HurtByCold = copyFrom.HurtByCold;
            HurtByFire = copyFrom.HurtByFire;
            HurtByLight = copyFrom.HurtByLight;
            HurtByRock = copyFrom.HurtByRock;
            ImmuneAcid = copyFrom.ImmuneAcid;
            ImmuneCold = copyFrom.ImmuneCold;
            ImmuneConfusion = copyFrom.ImmuneConfusion;
            ImmuneFear = copyFrom.ImmuneFear;
            ImmuneFire = copyFrom.ImmuneFire;
            ImmuneLightning = copyFrom.ImmuneLightning;
            ImmunePoison = copyFrom.ImmunePoison;
            ImmuneSleep = copyFrom.ImmuneSleep;
            ImmuneStun = copyFrom.ImmuneStun;
            Nonliving = copyFrom.Nonliving;
            Orc = copyFrom.Orc;
            ResistDisenchant = copyFrom.ResistDisenchant;
            ResistNether = copyFrom.ResistNether;
            ResistNexus = copyFrom.ResistNexus;
            ResistPlasma = copyFrom.ResistPlasma;
            ResistTeleport = copyFrom.ResistTeleport;
            ResistWater = copyFrom.ResistWater;
            Troll = copyFrom.Troll;
            Undead = copyFrom.Undead;
        }

        public MonsterCharacteristics(IMonsterCharacteristics copyFrom, IMonsterCharacteristics unionWith)
        {
            AttrClear = copyFrom.AttrClear & unionWith.AttrClear;
            AttrMulti = copyFrom.AttrMulti & unionWith.AttrMulti;
            CharClear = copyFrom.CharClear & unionWith.CharClear;
            CharMulti = copyFrom.CharMulti & unionWith.CharMulti;
            Drop_1D2 = copyFrom.Drop_1D2 & unionWith.Drop_1D2;
            Drop_2D2 = copyFrom.Drop_2D2 & unionWith.Drop_2D2;
            Drop_3D2 = copyFrom.Drop_3D2 & unionWith.Drop_3D2;
            Drop_4D2 = copyFrom.Drop_4D2 & unionWith.Drop_4D2;
            Drop60 = copyFrom.Drop60 & unionWith.Drop60;
            Drop90 = copyFrom.Drop90 & unionWith.Drop90;
            DropGood = copyFrom.DropGood & unionWith.DropGood;
            DropGreat = copyFrom.DropGreat & unionWith.DropGreat;
            Escorted = copyFrom.Escorted & unionWith.Escorted;
            EscortsGroup = copyFrom.EscortsGroup & unionWith.EscortsGroup;
            Female = copyFrom.Female & unionWith.Female;
            ForceMaxHp = copyFrom.ForceMaxHp & unionWith.ForceMaxHp;
            ForceSleep = copyFrom.ForceSleep & unionWith.ForceSleep;
            Friends = copyFrom.Friends & unionWith.Friends;
            Male = copyFrom.Male & unionWith.Male;
            NeverAttack = copyFrom.NeverAttack & unionWith.NeverAttack;
            NeverMove = copyFrom.NeverMove & unionWith.NeverMove;
            OnlyDropGold = copyFrom.OnlyDropGold & unionWith.OnlyDropGold;
            OnlyDropItem = copyFrom.OnlyDropItem & unionWith.OnlyDropItem;
            RandomMove25 = copyFrom.RandomMove25 & unionWith.RandomMove25;
            RandomMove50 = copyFrom.RandomMove50 & unionWith.RandomMove50;
            Unique = copyFrom.Unique & unionWith.Unique;
            AttrAny = copyFrom.AttrAny & unionWith.AttrAny;
            BashDoor = copyFrom.BashDoor & unionWith.BashDoor;
            ColdBlood = copyFrom.ColdBlood & unionWith.ColdBlood;
            EldritchHorror = copyFrom.EldritchHorror & unionWith.EldritchHorror;
            EmptyMind = copyFrom.EmptyMind & unionWith.EmptyMind;
            FireAura = copyFrom.FireAura & unionWith.FireAura;
            Invisible = copyFrom.Invisible & unionWith.Invisible;
            KillBody = copyFrom.KillBody & unionWith.KillBody;
            KillItem = copyFrom.KillItem & unionWith.KillItem;
            KillWall = copyFrom.KillWall & unionWith.KillWall;
            LightningAura = copyFrom.LightningAura & unionWith.LightningAura;
            MoveBody = copyFrom.MoveBody & unionWith.MoveBody;
            Multiply = copyFrom.Multiply & unionWith.Multiply;
            OpenDoor = copyFrom.OpenDoor & unionWith.OpenDoor;
            PassWall = copyFrom.PassWall & unionWith.PassWall;
            Powerful = copyFrom.Powerful & unionWith.Powerful;
            Reflecting = copyFrom.Reflecting & unionWith.Reflecting;
            Regenerate = copyFrom.Regenerate & unionWith.Regenerate;
            Shapechanger = copyFrom.Shapechanger & unionWith.Shapechanger;
            Smart = copyFrom.Smart & unionWith.Smart;
            Stupid = copyFrom.Stupid & unionWith.Stupid;
            TakeItem = copyFrom.TakeItem & unionWith.TakeItem;
            WeirdMind = copyFrom.WeirdMind & unionWith.WeirdMind;
            Animal = copyFrom.Animal & unionWith.Animal;
            Cthuloid = copyFrom.Cthuloid & unionWith.Cthuloid;
            Demon = copyFrom.Demon & unionWith.Demon;
            Dragon = copyFrom.Dragon & unionWith.Dragon;
            Evil = copyFrom.Evil & unionWith.Evil;
            Giant = copyFrom.Giant & unionWith.Giant;
            Good = copyFrom.Good & unionWith.Good;
            GreatOldOne = copyFrom.GreatOldOne & unionWith.GreatOldOne;
            HurtByCold = copyFrom.HurtByCold & unionWith.HurtByCold;
            HurtByFire = copyFrom.HurtByFire & unionWith.HurtByFire;
            HurtByLight = copyFrom.HurtByLight & unionWith.HurtByLight;
            HurtByRock = copyFrom.HurtByRock & unionWith.HurtByRock;
            ImmuneAcid = copyFrom.ImmuneAcid & unionWith.ImmuneAcid;
            ImmuneCold = copyFrom.ImmuneCold & unionWith.ImmuneCold;
            ImmuneConfusion = copyFrom.ImmuneConfusion & unionWith.ImmuneConfusion;
            ImmuneFear = copyFrom.ImmuneFear & unionWith.ImmuneFear;
            ImmuneFire = copyFrom.ImmuneFire & unionWith.ImmuneFire;
            ImmuneLightning = copyFrom.ImmuneLightning & unionWith.ImmuneLightning;
            ImmunePoison = copyFrom.ImmunePoison & unionWith.ImmunePoison;
            ImmuneSleep = copyFrom.ImmuneSleep & unionWith.ImmuneSleep;
            ImmuneStun = copyFrom.ImmuneStun & unionWith.ImmuneStun;
            Nonliving = copyFrom.Nonliving & unionWith.Nonliving;
            Orc = copyFrom.Orc & unionWith.Orc;
            ResistDisenchant = copyFrom.ResistDisenchant & unionWith.ResistDisenchant;
            ResistNether = copyFrom.ResistNether & unionWith.ResistNether;
            ResistNexus = copyFrom.ResistNexus & unionWith.ResistNexus;
            ResistPlasma = copyFrom.ResistPlasma & unionWith.ResistPlasma;
            ResistTeleport = copyFrom.ResistTeleport & unionWith.ResistTeleport;
            ResistWater = copyFrom.ResistWater & unionWith.ResistWater;
            Troll = copyFrom.Troll & unionWith.Troll;
            Undead = copyFrom.Undead & unionWith.Undead;
        }

        public bool AttrClear { get; set; }
        public bool AttrMulti { get; set; }
        public bool CharClear { get; set; }
        public bool CharMulti { get; set; }
        public bool Drop_1D2 { get; set; }
        public bool Drop_2D2 { get; set; }
        public bool Drop_3D2 { get; set; }
        public bool Drop_4D2 { get; set; }
        public bool Drop60 { get; set; }
        public bool Drop90 { get; set; }
        public bool DropGood { get; set; }
        public bool DropGreat { get; set; }
        public bool Escorted { get; set; }
        public bool EscortsGroup { get; set; }
        public bool Female { get; set; }
        public bool ForceMaxHp { get; set; }
        public bool ForceSleep { get; set; }
        public bool Friends { get; set; }
        public bool Male { get; set; }
        public bool NeverAttack { get; set; }
        public bool NeverMove { get; set; }
        public bool OnlyDropGold { get; set; }
        public bool OnlyDropItem { get; set; }
        public bool RandomMove25 { get; set; }
        public bool RandomMove50 { get; set; }
        public bool Unique { get; set; }

        public bool AttrAny { get; set; }
        public bool BashDoor { get; set; }
        public bool ColdBlood { get; set; }
        public bool EldritchHorror { get; set; }
        public bool EmptyMind { get; set; }
        public bool FireAura { get; set; }
        public bool Invisible { get; set; }
        public bool KillBody { get; set; }
        public bool KillItem { get; set; }
        public bool KillWall { get; set; }
        public bool LightningAura { get; set; }
        public bool MoveBody { get; set; }
        public bool Multiply { get; set; }
        public bool OpenDoor { get; set; }
        public bool PassWall { get; set; }
        public bool Powerful { get; set; }
        public bool Reflecting { get; set; }
        public bool Regenerate { get; set; }
        public bool Shapechanger { get; set; }
        public bool Smart { get; set; }
        public bool Stupid { get; set; }
        public bool TakeItem { get; set; }
        public bool WeirdMind { get; set; }

        public bool Animal { get; set; }
        public bool Cthuloid { get; set; }
        public bool Demon { get; set; }
        public bool Dragon { get; set; }
        public bool Evil { get; set; }
        public bool Giant { get; set; }
        public bool Good { get; set; }
        public bool GreatOldOne { get; set; }
        public bool HurtByCold { get; set; }
        public bool HurtByFire { get; set; }
        public bool HurtByLight { get; set; }
        public bool HurtByRock { get; set; }
        public bool ImmuneAcid { get; set; }
        public bool ImmuneCold { get; set; }
        public bool ImmuneConfusion { get; set; }
        public bool ImmuneFear { get; set; }
        public bool ImmuneFire { get; set; }
        public bool ImmuneLightning { get; set; }
        public bool ImmunePoison { get; set; }
        public bool ImmuneSleep { get; set; }
        public bool ImmuneStun { get; set; }
        public bool Nonliving { get; set; }
        public bool Orc { get; set; }
        public bool ResistDisenchant { get; set; }
        public bool ResistNether { get; set; }
        public bool ResistNexus { get; set; }
        public bool ResistPlasma { get; set; }
        public bool ResistTeleport { get; set; }
        public bool ResistWater { get; set; }
        public bool Troll { get; set; }
        public bool Undead { get; set; }
    }
}
