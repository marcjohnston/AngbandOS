// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Enumerations
{
    /// <summary>
    /// Represents an set of item characteristics.
    /// </summary>
    [Serializable]
    internal class ItemCharacteristics : IItemCharacteristics
    {
        public bool Blows { get; set; } = false;
        public bool BrandAcid { get; set; } = false;
        public bool BrandCold { get; set; } = false;
        public bool BrandElec { get; set; } = false;
        public bool BrandFire { get; set; } = false;
        public bool BrandPois { get; set; } = false;
        public bool Cha { get; set; } = false;
        public bool Chaotic { get; set; } = false;
        public bool Con { get; set; } = false;
        public bool Dex { get; set; } = false;
        public bool Impact { get; set; } = false;
        public bool Infra { get; set; } = false;
        public bool Int { get; set; } = false;
        public bool KillDragon { get; set; } = false;
        public bool Search { get; set; } = false;
        public bool SlayAnimal { get; set; } = false;
        public bool SlayDemon { get; set; } = false;
        public bool SlayDragon { get; set; } = false;
        public bool SlayEvil { get; set; } = false;
        public bool SlayGiant { get; set; } = false;
        public bool SlayOrc { get; set; } = false;
        public bool SlayTroll { get; set; } = false;
        public bool SlayUndead { get; set; } = false;
        public bool Speed { get; set; } = false;
        public bool Stealth { get; set; } = false;
        public bool Str { get; set; } = false;
        public bool Tunnel { get; set; } = false;
        public bool Vampiric { get; set; } = false;
        public bool Vorpal { get; set; } = false;
        public bool Wis { get; set; } = false;
        public bool FreeAct { get; set; } = false;
        public bool HoldLife { get; set; } = false;
        public bool ImAcid { get; set; } = false;
        public bool ImCold { get; set; } = false;
        public bool ImElec { get; set; } = false;
        public bool ImFire { get; set; } = false;
        public bool Reflect { get; set; } = false;
        public bool ResAcid { get; set; } = false;
        public bool ResBlind { get; set; } = false;
        public bool ResChaos { get; set; } = false;
        public bool ResCold { get; set; } = false;
        public bool ResConf { get; set; } = false;
        public bool ResDark { get; set; } = false;
        public bool ResDisen { get; set; } = false;
        public bool ResElec { get; set; } = false;
        public bool ResFear { get; set; } = false;
        public bool ResFire { get; set; } = false;
        public bool ResLight { get; set; } = false;
        public bool ResNether { get; set; } = false;
        public bool ResNexus { get; set; } = false;
        public bool ResPois { get; set; } = false;
        public bool ResShards { get; set; } = false;
        public bool ResSound { get; set; } = false;
        public bool SustCha { get; set; } = false;
        public bool SustCon { get; set; } = false;
        public bool SustDex { get; set; } = false;
        public bool SustInt { get; set; } = false;
        public bool SustStr { get; set; } = false;
        public bool SustWis { get; set; } = false;
        public bool AntiTheft { get; set; } = false;
        public bool Activate { get; set; } = false; // TODO: This should be IActivatible.IsAssignableFrom
        public bool Aggravate { get; set; } = false;
        public bool Blessed { get; set; } = false;
        public bool Cursed { get; set; } = false;
        public bool DrainExp { get; set; } = false;
        public bool DreadCurse { get; set; } = false;
        public bool EasyKnow { get; set; } = false;
        public bool Feather { get; set; } = false;
        public bool HeavyCurse { get; set; } = false;
        public bool HideType { get; set; } = false;
        public bool IgnoreAcid { get; set; } = false;
        public bool IgnoreCold { get; set; } = false;
        public bool IgnoreElec { get; set; } = false;
        public bool IgnoreFire { get; set; } = false;
        public bool InstaArt { get; set; } = false;
        public bool Lightsource { get; set; } = false;
        public bool NoMagic { get; set; } = false;
        public bool NoTele { get; set; } = false;
        public bool PermaCurse { get; set; } = false;
        public bool Regen { get; set; } = false;
        public bool SeeInvis { get; set; } = false;
        public bool ShElec { get; set; } = false;
        public bool ShFire { get; set; } = false;
        public bool ShowMods { get; set; } = false;
        public bool SlowDigest { get; set; } = false;
        public bool Telepathy { get; set; } = false;
        public bool Teleport { get; set; } = false;
        public bool Wraith { get; set; } = false;
        public bool XtraMight { get; set; } = false;
        public bool XtraShots { get; set; } = false;

        /// <summary>
        /// Imports the characteristics of another item.
        /// </summary>
        /// <param name="itemCharacteristicsA"></param>
        /// <param name="itemCharacteristicsB"></param>
        public void Copy(IItemCharacteristics itemCharacteristics)
        {
            Blows = itemCharacteristics.Blows;
            BrandAcid = itemCharacteristics.BrandAcid;
            BrandCold = itemCharacteristics.BrandCold;
            BrandElec = itemCharacteristics.BrandElec;
            BrandFire = itemCharacteristics.BrandFire;
            BrandPois = itemCharacteristics.BrandPois;
            Cha = itemCharacteristics.Cha;
            Chaotic = itemCharacteristics.Chaotic;
            Con = itemCharacteristics.Con;
            Dex = itemCharacteristics.Dex;
            Impact = itemCharacteristics.Impact;
            Infra = itemCharacteristics.Infra;
            Int = itemCharacteristics.Int;
            KillDragon = itemCharacteristics.KillDragon;
            Search = itemCharacteristics.Search;
            SlayAnimal = itemCharacteristics.SlayAnimal;
            SlayDemon = itemCharacteristics.SlayDemon;
            SlayDragon = itemCharacteristics.SlayDragon;
            SlayEvil = itemCharacteristics.SlayEvil;
            SlayGiant = itemCharacteristics.SlayGiant;
            SlayOrc = itemCharacteristics.SlayOrc;
            SlayTroll = itemCharacteristics.SlayTroll;
            SlayUndead = itemCharacteristics.SlayUndead;
            Speed = itemCharacteristics.Speed;
            Stealth = itemCharacteristics.Stealth;
            Str = itemCharacteristics.Str;
            Tunnel = itemCharacteristics.Tunnel;
            Vampiric = itemCharacteristics.Vampiric;
            Vorpal = itemCharacteristics.Vorpal;
            Wis = itemCharacteristics.Wis;
            FreeAct = itemCharacteristics.FreeAct;
            HoldLife = itemCharacteristics.HoldLife;
            ImAcid = itemCharacteristics.ImAcid;
            ImCold = itemCharacteristics.ImCold;
            ImElec = itemCharacteristics.ImElec;
            ImFire = itemCharacteristics.ImFire;
            Reflect = itemCharacteristics.Reflect;
            ResAcid = itemCharacteristics.ResAcid;
            ResBlind = itemCharacteristics.ResBlind;
            ResChaos = itemCharacteristics.ResChaos;
            ResCold = itemCharacteristics.ResCold;
            ResConf = itemCharacteristics.ResConf;
            ResDark = itemCharacteristics.ResDark;
            ResDisen = itemCharacteristics.ResDisen;
            ResElec = itemCharacteristics.ResElec;
            ResFear = itemCharacteristics.ResFear;
            ResFire = itemCharacteristics.ResFire;
            ResLight = itemCharacteristics.ResLight;
            ResNether = itemCharacteristics.ResNether;
            ResNexus = itemCharacteristics.ResNexus;
            ResPois = itemCharacteristics.ResPois;
            ResShards = itemCharacteristics.ResShards;
            ResSound = itemCharacteristics.ResSound;
            SustCha = itemCharacteristics.SustCha;
            SustCon = itemCharacteristics.SustCon;
            SustDex = itemCharacteristics.SustDex;
            SustInt = itemCharacteristics.SustInt;
            SustStr = itemCharacteristics.SustStr;
            SustWis = itemCharacteristics.SustWis;
            AntiTheft = itemCharacteristics.AntiTheft;
            Activate = itemCharacteristics.Activate;
            Aggravate = itemCharacteristics.Aggravate;
            Blessed = itemCharacteristics.Blessed;
            Cursed = itemCharacteristics.Cursed;
            DrainExp = itemCharacteristics.DrainExp;
            DreadCurse = itemCharacteristics.DreadCurse;
            EasyKnow = itemCharacteristics.EasyKnow;
            Feather = itemCharacteristics.Feather;
            HeavyCurse = itemCharacteristics.HeavyCurse;
            HideType = itemCharacteristics.HideType;
            IgnoreAcid = itemCharacteristics.IgnoreAcid;
            IgnoreCold = itemCharacteristics.IgnoreCold;
            IgnoreElec = itemCharacteristics.IgnoreElec;
            IgnoreFire = itemCharacteristics.IgnoreFire;
            InstaArt = itemCharacteristics.InstaArt;
            Lightsource = itemCharacteristics.Lightsource;
            NoMagic = itemCharacteristics.NoMagic;
            NoTele = itemCharacteristics.NoTele;
            PermaCurse = itemCharacteristics.PermaCurse;
            Regen = itemCharacteristics.Regen;
            SeeInvis = itemCharacteristics.SeeInvis;
            ShElec = itemCharacteristics.ShElec;
            ShFire = itemCharacteristics.ShFire;
            ShowMods = itemCharacteristics.ShowMods;
            SlowDigest = itemCharacteristics.SlowDigest;
            Telepathy = itemCharacteristics.Telepathy;
            Teleport = itemCharacteristics.Teleport;
            Wraith = itemCharacteristics.Wraith;
            XtraMight = itemCharacteristics.XtraMight;
            XtraShots = itemCharacteristics.XtraShots;
        }

        /// <summary>
        /// Merge the characteristics of another item using the an OR operation.
        /// </summary>
        /// <param name="itemCharacteristics"></param>
        public void Merge(IItemCharacteristics itemCharacteristics)
        {
            Blows = Blows || itemCharacteristics.Blows;
            BrandAcid = BrandAcid || itemCharacteristics.BrandAcid;
            BrandCold = BrandCold || itemCharacteristics.BrandCold;
            BrandElec = BrandElec || itemCharacteristics.BrandElec;
            BrandFire = BrandFire || itemCharacteristics.BrandFire;
            BrandPois = BrandPois || itemCharacteristics.BrandPois;
            Cha = Cha || itemCharacteristics.Cha;
            Chaotic = Chaotic || itemCharacteristics.Chaotic;
            Con = Con || itemCharacteristics.Con;
            Dex = Dex || itemCharacteristics.Dex;
            Impact = Impact || itemCharacteristics.Impact;
            Infra = Infra || itemCharacteristics.Infra;
            Int = Int || itemCharacteristics.Int;
            KillDragon = KillDragon || itemCharacteristics.KillDragon;
            Search = Search || itemCharacteristics.Search;
            SlayAnimal = SlayAnimal || itemCharacteristics.SlayAnimal;
            SlayDemon = SlayDemon || itemCharacteristics.SlayDemon;
            SlayDragon = SlayDragon || itemCharacteristics.SlayDragon;
            SlayEvil = SlayEvil || itemCharacteristics.SlayEvil;
            SlayGiant = SlayGiant || itemCharacteristics.SlayGiant;
            SlayOrc = SlayOrc || itemCharacteristics.SlayOrc;
            SlayTroll = SlayTroll || itemCharacteristics.SlayTroll;
            SlayUndead = SlayUndead || itemCharacteristics.SlayUndead;
            Speed = Speed || itemCharacteristics.Speed;
            Stealth = Stealth || itemCharacteristics.Stealth;
            Str = Str || itemCharacteristics.Str;
            Tunnel = Tunnel || itemCharacteristics.Tunnel;
            Vampiric = Vampiric || itemCharacteristics.Vampiric;
            Vorpal = Vorpal || itemCharacteristics.Vorpal;
            Wis = Wis || itemCharacteristics.Wis;
            FreeAct = FreeAct || itemCharacteristics.FreeAct;
            HoldLife = HoldLife || itemCharacteristics.HoldLife;
            ImAcid = ImAcid || itemCharacteristics.ImAcid;
            ImCold = ImCold || itemCharacteristics.ImCold;
            ImElec = ImElec || itemCharacteristics.ImElec;
            ImFire = ImFire || itemCharacteristics.ImFire;
            Reflect = Reflect || itemCharacteristics.Reflect;
            ResAcid = ResAcid || itemCharacteristics.ResAcid;
            ResBlind = ResBlind || itemCharacteristics.ResBlind;
            ResChaos = ResChaos || itemCharacteristics.ResChaos;
            ResCold = ResCold || itemCharacteristics.ResCold;
            ResConf = ResConf || itemCharacteristics.ResConf;
            ResDark = ResDark || itemCharacteristics.ResDark;
            ResDisen = ResDisen || itemCharacteristics.ResDisen;
            ResElec = ResElec || itemCharacteristics.ResElec;
            ResFear = ResFear || itemCharacteristics.ResFear;
            ResFire = ResFire || itemCharacteristics.ResFire;
            ResLight = ResLight || itemCharacteristics.ResLight;
            ResNether = ResNether || itemCharacteristics.ResNether;
            ResNexus = ResNexus || itemCharacteristics.ResNexus;
            ResPois = ResPois || itemCharacteristics.ResPois;
            ResShards = ResShards || itemCharacteristics.ResShards;
            ResSound = ResSound || itemCharacteristics.ResSound;
            SustCha = SustCha || itemCharacteristics.SustCha;
            SustCon = SustCon || itemCharacteristics.SustCon;
            SustDex = SustDex || itemCharacteristics.SustDex;
            SustInt = SustInt || itemCharacteristics.SustInt;
            SustStr = SustStr || itemCharacteristics.SustStr;
            SustWis = SustWis || itemCharacteristics.SustWis;
            AntiTheft = AntiTheft || itemCharacteristics.AntiTheft;
            Activate = Activate || itemCharacteristics.Activate;
            Aggravate = Aggravate || itemCharacteristics.Aggravate;
            Blessed = Blessed || itemCharacteristics.Blessed;
            Cursed = Cursed || itemCharacteristics.Cursed;
            DrainExp = DrainExp || itemCharacteristics.DrainExp;
            DreadCurse = DreadCurse || itemCharacteristics.DreadCurse;
            EasyKnow = EasyKnow || itemCharacteristics.EasyKnow;
            Feather = Feather || itemCharacteristics.Feather;
            HeavyCurse = HeavyCurse || itemCharacteristics.HeavyCurse;
            HideType = HideType || itemCharacteristics.HideType;
            IgnoreAcid = IgnoreAcid || itemCharacteristics.IgnoreAcid;
            IgnoreCold = IgnoreCold || itemCharacteristics.IgnoreCold;
            IgnoreElec = IgnoreElec || itemCharacteristics.IgnoreElec;
            IgnoreFire = IgnoreFire || itemCharacteristics.IgnoreFire;
            InstaArt = InstaArt || itemCharacteristics.InstaArt;
            Lightsource = Lightsource || itemCharacteristics.Lightsource;
            NoMagic = NoMagic || itemCharacteristics.NoMagic;
            NoTele = NoTele || itemCharacteristics.NoTele;
            PermaCurse = PermaCurse || itemCharacteristics.PermaCurse;
            Regen = Regen || itemCharacteristics.Regen;
            SeeInvis = SeeInvis || itemCharacteristics.SeeInvis;
            ShElec = ShElec || itemCharacteristics.ShElec;
            ShFire = ShFire || itemCharacteristics.ShFire;
            ShowMods = ShowMods || itemCharacteristics.ShowMods;
            SlowDigest = SlowDigest || itemCharacteristics.SlowDigest;
            Telepathy = Telepathy || itemCharacteristics.Telepathy;
            Teleport = Teleport || itemCharacteristics.Teleport;
            Wraith = Wraith || itemCharacteristics.Wraith;
            XtraMight = XtraMight || itemCharacteristics.XtraMight;
            XtraShots = XtraShots || itemCharacteristics.XtraShots;
        }

        /// <summary>
        /// Resets all of the characteristics to false.
        /// </summary>
        public void Clear()
        {
            Blows = false;
            BrandAcid = false;
            BrandCold = false;
            BrandElec = false;
            BrandFire = false;
            BrandPois = false;
            Cha = false;
            Chaotic = false;
            Con = false;
            Dex = false;
            Impact = false;
            Infra = false;
            Int = false;
            KillDragon = false;
            Search = false;
            SlayAnimal = false;
            SlayDemon = false;
            SlayDragon = false;
            SlayEvil = false;
            SlayGiant = false;
            SlayOrc = false;
            SlayTroll = false;
            SlayUndead = false;
            Speed = false;
            Stealth = false;
            Str = false;
            Tunnel = false;
            Vampiric = false;
            Vorpal = false;
            Wis = false;
            FreeAct = false;
            HoldLife = false;
            ImAcid = false;
            ImCold = false;
            ImElec = false;
            ImFire = false;
            Reflect = false;
            ResAcid = false;
            ResBlind = false;
            ResChaos = false;
            ResCold = false;
            ResConf = false;
            ResDark = false;
            ResDisen = false;
            ResElec = false;
            ResFear = false;
            ResFire = false;
            ResLight = false;
            ResNether = false;
            ResNexus = false;
            ResPois = false;
            ResShards = false;
            ResSound = false;
            SustCha = false;
            SustCon = false;
            SustDex = false;
            SustInt = false;
            SustStr = false;
            SustWis = false;
            AntiTheft = false;
            Activate = false;
            Aggravate = false;
            Blessed = false;
            Cursed = false;
            DrainExp = false;
            DreadCurse = false;
            EasyKnow = false;
            Feather = false;
            HeavyCurse = false;
            HideType = false;
            IgnoreAcid = false;
            IgnoreCold = false;
            IgnoreElec = false;
            IgnoreFire = false;
            InstaArt = false;
            Lightsource = false;
            NoMagic = false;
            NoTele = false;
            PermaCurse = false;
            Regen = false;
            SeeInvis = false;
            ShElec = false;
            ShFire = false;
            ShowMods = false;
            SlowDigest = false;
            Telepathy = false;
            Teleport = false;
            Wraith = false;
            XtraMight = false;
            XtraShots = false;
        }

        /// <summary>
        /// Returns true, if any characteristic is set.
        /// </summary>
        /// <returns></returns>
        public bool IsSet
        {
            get
            {
                if (Blows) return true;
                if (BrandAcid) return true;
                if (BrandCold) return true;
                if (BrandElec) return true;
                if (BrandFire) return true;
                if (BrandPois) return true;
                if (Cha) return true;
                if (Chaotic) return true;
                if (Con) return true;
                if (Dex) return true;
                if (Impact) return true;
                if (Infra) return true;
                if (Int) return true;
                if (KillDragon) return true;
                if (Search) return true;
                if (SlayAnimal) return true;
                if (SlayDemon) return true;
                if (SlayDragon) return true;
                if (SlayEvil) return true;
                if (SlayGiant) return true;
                if (SlayOrc) return true;
                if (SlayTroll) return true;
                if (SlayUndead) return true;
                if (Speed) return true;
                if (Stealth) return true;
                if (Str) return true;
                if (Tunnel) return true;
                if (Vampiric) return true;
                if (Vorpal) return true;
                if (Wis) return true;
                if (FreeAct) return true;
                if (HoldLife) return true;
                if (ImAcid) return true;
                if (ImCold) return true;
                if (ImElec) return true;
                if (ImFire) return true;
                if (Reflect) return true;
                if (ResAcid) return true;
                if (ResBlind) return true;
                if (ResChaos) return true;
                if (ResCold) return true;
                if (ResConf) return true;
                if (ResDark) return true;
                if (ResDisen) return true;
                if (ResElec) return true;
                if (ResFear) return true;
                if (ResFire) return true;
                if (ResLight) return true;
                if (ResNether) return true;
                if (ResNexus) return true;
                if (ResPois) return true;
                if (ResShards) return true;
                if (ResSound) return true;
                if (SustCha) return true;
                if (SustCon) return true;
                if (SustDex) return true;
                if (SustInt) return true;
                if (SustStr) return true;
                if (SustWis) return true;
                if (AntiTheft) return true;
                if (Activate) return true;
                if (Aggravate) return true;
                if (Blessed) return true;
                if (Cursed) return true;
                if (DrainExp) return true;
                if (DreadCurse) return true;
                if (EasyKnow) return true;
                if (Feather) return true;
                if (HeavyCurse) return true;
                if (HideType) return true;
                if (IgnoreAcid) return true;
                if (IgnoreCold) return true;
                if (IgnoreElec) return true;
                if (IgnoreFire) return true;
                if (InstaArt) return true;
                if (Lightsource) return true;
                if (NoMagic) return true;
                if (NoTele) return true;
                if (PermaCurse) return true;
                if (Regen) return true;
                if (SeeInvis) return true;
                if (ShElec) return true;
                if (ShFire) return true;
                if (ShowMods) return true;
                if (SlowDigest) return true;
                if (Telepathy) return true;
                if (Teleport) return true;
                if (Wraith) return true;
                if (XtraMight) return true;
                if (XtraShots) return true;
                return false;
            }
        }

        /// <summary>
        /// Creates a new set of ItemCharacteristics with all false values.
        /// </summary>
        public ItemCharacteristics()
        {
        }

        ///// <summary>
        ///// Creates a new set of ItemCharacteristics by performing a set "OR" operation on all of the ItemCharacteristics objects provided.
        ///// </summary>
        ///// <param name="mergeItemCharacteristics"></param>
        //public ItemCharacteristics(params IItemCharacteristics[] mergeItemCharacteristics)
        //{
        //    ItemCharacteristics tempItemCharacteristics = new ItemCharacteristics();
        //    foreach (ItemCharacteristics itemCharacteristics in mergeItemCharacteristics)
        //    {
        //        tempItemCharacteristics = new ItemCharacteristics(tempItemCharacteristics, itemCharacteristics);
        //    }
        //}

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            // We can compare if the object inherits from the IItemCharacteristics interface.
            if (!typeof(IItemCharacteristics).IsAssignableFrom(obj.GetType()))
                return false;

            IItemCharacteristics objCharacteristics = (IItemCharacteristics)obj;
            if (Blows != objCharacteristics.Blows) return false;
            if (BrandAcid != objCharacteristics.BrandAcid) return false;
            if (BrandCold != objCharacteristics.BrandCold) return false;
            if (BrandElec != objCharacteristics.BrandElec) return false;
            if (BrandFire != objCharacteristics.BrandFire) return false;
            if (BrandPois != objCharacteristics.BrandPois) return false;
            if (Cha != objCharacteristics.Cha) return false;
            if (Chaotic != objCharacteristics.Chaotic) return false;
            if (Con != objCharacteristics.Con) return false;
            if (Dex != objCharacteristics.Dex) return false;
            if (Impact != objCharacteristics.Impact) return false;
            if (Infra != objCharacteristics.Infra) return false;
            if (Int != objCharacteristics.Int) return false;
            if (KillDragon != objCharacteristics.KillDragon) return false;
            if (Search != objCharacteristics.Search) return false;
            if (SlayAnimal != objCharacteristics.SlayAnimal) return false;
            if (SlayDemon != objCharacteristics.SlayDemon) return false;
            if (SlayDragon != objCharacteristics.SlayDragon) return false;
            if (SlayEvil != objCharacteristics.SlayEvil) return false;
            if (SlayGiant != objCharacteristics.SlayGiant) return false;
            if (SlayOrc != objCharacteristics.SlayOrc) return false;
            if (SlayTroll != objCharacteristics.SlayTroll) return false;
            if (SlayUndead != objCharacteristics.SlayUndead) return false;
            if (Speed != objCharacteristics.Speed) return false;
            if (Stealth != objCharacteristics.Stealth) return false;
            if (Str != objCharacteristics.Str) return false;
            if (Tunnel != objCharacteristics.Tunnel) return false;
            if (Vampiric != objCharacteristics.Vampiric) return false;
            if (Vorpal != objCharacteristics.Vorpal) return false;
            if (Wis != objCharacteristics.Wis) return false;
            if (FreeAct != objCharacteristics.FreeAct) return false;
            if (HoldLife != objCharacteristics.HoldLife) return false;
            if (ImAcid != objCharacteristics.ImAcid) return false;
            if (ImCold != objCharacteristics.ImCold) return false;
            if (ImElec != objCharacteristics.ImElec) return false;
            if (ImFire != objCharacteristics.ImFire) return false;
            if (Reflect != objCharacteristics.Reflect) return false;
            if (ResAcid != objCharacteristics.ResAcid) return false;
            if (ResBlind != objCharacteristics.ResBlind) return false;
            if (ResChaos != objCharacteristics.ResChaos) return false;
            if (ResCold != objCharacteristics.ResCold) return false;
            if (ResConf != objCharacteristics.ResConf) return false;
            if (ResDark != objCharacteristics.ResDark) return false;
            if (ResDisen != objCharacteristics.ResDisen) return false;
            if (ResElec != objCharacteristics.ResElec) return false;
            if (ResFear != objCharacteristics.ResFear) return false;
            if (ResFire != objCharacteristics.ResFire) return false;
            if (ResLight != objCharacteristics.ResLight) return false;
            if (ResNether != objCharacteristics.ResNether) return false;
            if (ResNexus != objCharacteristics.ResNexus) return false;
            if (ResPois != objCharacteristics.ResPois) return false;
            if (ResShards != objCharacteristics.ResShards) return false;
            if (ResSound != objCharacteristics.ResSound) return false;
            if (SustCha != objCharacteristics.SustCha) return false;
            if (SustCon != objCharacteristics.SustCon) return false;
            if (SustDex != objCharacteristics.SustDex) return false;
            if (SustInt != objCharacteristics.SustInt) return false;
            if (SustStr != objCharacteristics.SustStr) return false;
            if (SustWis != objCharacteristics.SustWis) return false;
            if (AntiTheft != objCharacteristics.AntiTheft) return false;
            if (Activate != objCharacteristics.Activate) return false;
            if (Aggravate != objCharacteristics.Aggravate) return false;
            if (Blessed != objCharacteristics.Blessed) return false;
            if (Cursed != objCharacteristics.Cursed) return false;
            if (DrainExp != objCharacteristics.DrainExp) return false;
            if (DreadCurse != objCharacteristics.DreadCurse) return false;
            if (EasyKnow != objCharacteristics.EasyKnow) return false;
            if (Feather != objCharacteristics.Feather) return false;
            if (HeavyCurse != objCharacteristics.HeavyCurse) return false;
            if (HideType != objCharacteristics.HideType) return false;
            if (IgnoreAcid != objCharacteristics.IgnoreAcid) return false;
            if (IgnoreCold != objCharacteristics.IgnoreCold) return false;
            if (IgnoreElec != objCharacteristics.IgnoreElec) return false;
            if (IgnoreFire != objCharacteristics.IgnoreFire) return false;
            if (InstaArt != objCharacteristics.InstaArt) return false;
            if (Lightsource != objCharacteristics.Lightsource) return false;
            if (NoMagic != objCharacteristics.NoMagic) return false;
            if (NoTele != objCharacteristics.NoTele) return false;
            if (PermaCurse != objCharacteristics.PermaCurse) return false;
            if (Regen != objCharacteristics.Regen) return false;
            if (SeeInvis != objCharacteristics.SeeInvis) return false;
            if (ShElec != objCharacteristics.ShElec) return false;
            if (ShFire != objCharacteristics.ShFire) return false;
            if (ShowMods != objCharacteristics.ShowMods) return false;
            if (SlowDigest != objCharacteristics.SlowDigest) return false;
            if (Telepathy != objCharacteristics.Telepathy) return false;
            if (Teleport != objCharacteristics.Teleport) return false;
            if (Wraith != objCharacteristics.Wraith) return false;
            if (XtraMight != objCharacteristics.XtraMight) return false;
            if (XtraShots != objCharacteristics.XtraShots) return false;
            return true;
        }

        public static bool operator !=(ItemCharacteristics x, IItemCharacteristics y)
        {
            return !x.Equals(y);
        }

        public static bool operator ==(ItemCharacteristics x, IItemCharacteristics y)
        {
            return x.Equals(y);
        }
    }
}