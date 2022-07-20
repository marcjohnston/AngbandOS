using System.Collections.Generic;
using System;
using System.Reflection;
namespace Cthangband.Commands
{ 
    internal interface ICommand
    {
        char Key { get; }
        bool Repeatable { get; }
        bool IsEnabled { get; }
        void Execute(Player player, Level level);
    }
}
