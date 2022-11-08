// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Enumerations;
using AngbandOS.StaticData;
using System;
using AngbandOS.Core;
using AngbandOS.ItemCategories;

namespace AngbandOS
{
    [Serializable]
    internal class FixedArtifact
    {
        public readonly FlagSet Flags1 = new FlagSet();
        public readonly FlagSet Flags2 = new FlagSet();
        public readonly FlagSet Flags3 = new FlagSet();
        public readonly ItemCharacteristics FixedArtifactItemCharacteristics = new ItemCharacteristics();
        public int Ac;
        public int Cost;

        /// <summary>
        /// Represents the quantity of this artifact currently in existence.
        /// </summary>
        public int CurNum;

        public int Dd;
        public int Ds;
        public bool HasOwnType;
        public int Level;
        public string Name;
        public int Pval;
        public int Rarity;

        public int ToA;
        public int ToD;
        public int ToH;

        public int Weight;
        public readonly BaseItemCategory BaseItemCategory;

        public FixedArtifact(Base2FixedArtifact baseFixedArtifact)
        {
            BaseItemCategory = baseFixedArtifact.BaseItemCategory;

            Ac = baseFixedArtifact.Ac;
            Cost = baseFixedArtifact.Cost;
            CurNum = 0;
            Dd = baseFixedArtifact.Dd;
            Ds = baseFixedArtifact.Ds;
            Level = baseFixedArtifact.Level;
            Name = baseFixedArtifact.FriendlyName;
            Pval = baseFixedArtifact.Pval;
            Rarity = baseFixedArtifact.Rarity;
            ToA = baseFixedArtifact.ToA;
            ToD = baseFixedArtifact.ToD;
            ToH = baseFixedArtifact.ToH;
            Weight = baseFixedArtifact.Weight;
            HasOwnType = baseFixedArtifact.HasOwnType;

            FixedArtifactItemCharacteristics.Merge(baseFixedArtifact);
            Flags1.Set(baseFixedArtifact.Blows ? ItemFlag1.Blows : 0);
            Flags1.Set(baseFixedArtifact.BrandAcid ? ItemFlag1.BrandAcid : 0);
            Flags1.Set(baseFixedArtifact.BrandCold ? ItemFlag1.BrandCold : 0);
            Flags1.Set(baseFixedArtifact.BrandElec ? ItemFlag1.BrandElec : 0);
            Flags1.Set(baseFixedArtifact.BrandFire ? ItemFlag1.BrandFire : 0);
            Flags1.Set(baseFixedArtifact.BrandPois ? ItemFlag1.BrandPois : 0);
            Flags1.Set(baseFixedArtifact.Cha ? ItemFlag1.Cha : 0);
            Flags1.Set(baseFixedArtifact.Chaotic ? ItemFlag1.Chaotic : 0);
            Flags1.Set(baseFixedArtifact.Con ? ItemFlag1.Con : 0);
            Flags1.Set(baseFixedArtifact.Dex ? ItemFlag1.Dex : 0);
            Flags1.Set(baseFixedArtifact.Impact ? ItemFlag1.Impact : 0);
            Flags1.Set(baseFixedArtifact.Infra ? ItemFlag1.Infra : 0);
            Flags1.Set(baseFixedArtifact.Int ? ItemFlag1.Int : 0);
            Flags1.Set(baseFixedArtifact.KillDragon ? ItemFlag1.KillDragon : 0);
            Flags1.Set(baseFixedArtifact.Search ? ItemFlag1.Search : 0);
            Flags1.Set(baseFixedArtifact.SlayAnimal ? ItemFlag1.SlayAnimal : 0);
            Flags1.Set(baseFixedArtifact.SlayDemon ? ItemFlag1.SlayDemon : 0);
            Flags1.Set(baseFixedArtifact.SlayDragon ? ItemFlag1.SlayDragon : 0);
            Flags1.Set(baseFixedArtifact.SlayEvil ? ItemFlag1.SlayEvil : 0);
            Flags1.Set(baseFixedArtifact.SlayGiant ? ItemFlag1.SlayGiant : 0);
            Flags1.Set(baseFixedArtifact.SlayOrc ? ItemFlag1.SlayOrc : 0);
            Flags1.Set(baseFixedArtifact.SlayTroll ? ItemFlag1.SlayTroll : 0);
            Flags1.Set(baseFixedArtifact.SlayUndead ? ItemFlag1.SlayUndead : 0);
            Flags1.Set(baseFixedArtifact.Speed ? ItemFlag1.Speed : 0);
            Flags1.Set(baseFixedArtifact.Stealth ? ItemFlag1.Stealth : 0);
            Flags1.Set(baseFixedArtifact.Str ? ItemFlag1.Str : 0);
            Flags1.Set(baseFixedArtifact.Tunnel ? ItemFlag1.Tunnel : 0);
            Flags1.Set(baseFixedArtifact.Vampiric ? ItemFlag1.Vampiric : 0);
            Flags1.Set(baseFixedArtifact.Vorpal ? ItemFlag1.Vorpal : 0);
            Flags1.Set(baseFixedArtifact.Wis ? ItemFlag1.Wis : 0);
            Flags2.Set(baseFixedArtifact.FreeAct ? ItemFlag2.FreeAct : 0);
            Flags2.Set(baseFixedArtifact.HoldLife ? ItemFlag2.HoldLife : 0);
            Flags2.Set(baseFixedArtifact.ImAcid ? ItemFlag2.ImAcid : 0);
            Flags2.Set(baseFixedArtifact.ImCold ? ItemFlag2.ImCold : 0);
            Flags2.Set(baseFixedArtifact.ImElec ? ItemFlag2.ImElec : 0);
            Flags2.Set(baseFixedArtifact.ImFire ? ItemFlag2.ImFire : 0);
            Flags2.Set(baseFixedArtifact.Reflect ? ItemFlag2.Reflect : 0);
            Flags2.Set(baseFixedArtifact.ResAcid ? ItemFlag2.ResAcid : 0);
            Flags2.Set(baseFixedArtifact.ResBlind ? ItemFlag2.ResBlind : 0);
            Flags2.Set(baseFixedArtifact.ResChaos ? ItemFlag2.ResChaos : 0);
            Flags2.Set(baseFixedArtifact.ResCold ? ItemFlag2.ResCold : 0);
            Flags2.Set(baseFixedArtifact.ResConf ? ItemFlag2.ResConf : 0);
            Flags2.Set(baseFixedArtifact.ResDark ? ItemFlag2.ResDark : 0);
            Flags2.Set(baseFixedArtifact.ResDisen ? ItemFlag2.ResDisen : 0);
            Flags2.Set(baseFixedArtifact.ResElec ? ItemFlag2.ResElec : 0);
            Flags2.Set(baseFixedArtifact.ResFear ? ItemFlag2.ResFear : 0);
            Flags2.Set(baseFixedArtifact.ResFire ? ItemFlag2.ResFire : 0);
            Flags2.Set(baseFixedArtifact.ResLight ? ItemFlag2.ResLight : 0);
            Flags2.Set(baseFixedArtifact.ResNether ? ItemFlag2.ResNether : 0);
            Flags2.Set(baseFixedArtifact.ResNexus ? ItemFlag2.ResNexus : 0);
            Flags2.Set(baseFixedArtifact.ResPois ? ItemFlag2.ResPois : 0);
            Flags2.Set(baseFixedArtifact.ResShards ? ItemFlag2.ResShards : 0);
            Flags2.Set(baseFixedArtifact.ResSound ? ItemFlag2.ResSound : 0);
            Flags2.Set(baseFixedArtifact.SustCha ? ItemFlag2.SustCha : 0);
            Flags2.Set(baseFixedArtifact.SustCon ? ItemFlag2.SustCon : 0);
            Flags2.Set(baseFixedArtifact.SustDex ? ItemFlag2.SustDex : 0);
            Flags2.Set(baseFixedArtifact.SustInt ? ItemFlag2.SustInt : 0);
            Flags2.Set(baseFixedArtifact.SustStr ? ItemFlag2.SustStr : 0);
            Flags2.Set(baseFixedArtifact.SustWis ? ItemFlag2.SustWis : 0);
            Flags3.Set(baseFixedArtifact.Activate ? ItemFlag3.Activate : 0);
            Flags3.Set(baseFixedArtifact.Aggravate ? ItemFlag3.Aggravate : 0);
            Flags3.Set(baseFixedArtifact.Blessed ? ItemFlag3.Blessed : 0);
            Flags3.Set(baseFixedArtifact.Cursed ? ItemFlag3.Cursed : 0);
            Flags3.Set(baseFixedArtifact.DrainExp ? ItemFlag3.DrainExp : 0);
            Flags3.Set(baseFixedArtifact.DreadCurse ? ItemFlag3.DreadCurse : 0);
            Flags3.Set(baseFixedArtifact.EasyKnow ? ItemFlag3.EasyKnow : 0);
            Flags3.Set(baseFixedArtifact.Feather ? ItemFlag3.Feather : 0);
            Flags3.Set(baseFixedArtifact.HeavyCurse ? ItemFlag3.HeavyCurse : 0);
            Flags3.Set(baseFixedArtifact.HideType ? ItemFlag3.HideType : 0);
            Flags3.Set(baseFixedArtifact.IgnoreAcid ? ItemFlag3.IgnoreAcid : 0);
            Flags3.Set(baseFixedArtifact.IgnoreCold ? ItemFlag3.IgnoreCold : 0);
            Flags3.Set(baseFixedArtifact.IgnoreElec ? ItemFlag3.IgnoreElec : 0);
            Flags3.Set(baseFixedArtifact.IgnoreFire ? ItemFlag3.IgnoreFire : 0);
            Flags3.Set(baseFixedArtifact.InstaArt ? ItemFlag3.InstaArt : 0);
            Flags3.Set(baseFixedArtifact.Lightsource ? ItemFlag3.Lightsource : 0);
            Flags3.Set(baseFixedArtifact.NoMagic ? ItemFlag3.NoMagic : 0);
            Flags3.Set(baseFixedArtifact.NoTele ? ItemFlag3.NoTele : 0);
            Flags3.Set(baseFixedArtifact.PermaCurse ? ItemFlag3.PermaCurse : 0);
            Flags3.Set(baseFixedArtifact.Regen ? ItemFlag3.Regen : 0);
            Flags3.Set(baseFixedArtifact.SeeInvis ? ItemFlag3.SeeInvis : 0);
            Flags3.Set(baseFixedArtifact.ShElec ? ItemFlag3.ShElec : 0);
            Flags3.Set(baseFixedArtifact.ShFire ? ItemFlag3.ShFire : 0);
            Flags3.Set(baseFixedArtifact.ShowMods ? ItemFlag3.ShowMods : 0);
            Flags3.Set(baseFixedArtifact.SlowDigest ? ItemFlag3.SlowDigest : 0);
            Flags3.Set(baseFixedArtifact.Telepathy ? ItemFlag3.Telepathy : 0);
            Flags3.Set(baseFixedArtifact.Teleport ? ItemFlag3.Teleport : 0);
            Flags3.Set(baseFixedArtifact.Wraith ? ItemFlag3.Wraith : 0);
            Flags3.Set(baseFixedArtifact.XtraMight ? ItemFlag3.XtraMight : 0);
            Flags3.Set(baseFixedArtifact.XtraShots ? ItemFlag3.XtraShots : 0);
        }
    }
}