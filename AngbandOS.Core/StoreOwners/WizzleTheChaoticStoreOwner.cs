﻿// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreOwners;

[Serializable]
internal class WizzleTheChaoticStoreOwner : StoreOwner
{
    private WizzleTheChaoticStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Wizzle the Chaotic";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HobbitRace>();
}