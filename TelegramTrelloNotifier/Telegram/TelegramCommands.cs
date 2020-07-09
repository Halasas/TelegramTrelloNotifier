using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TrelloTelegramAlarm
{
    public static class TelegramCommands
    {
        private static readonly List<ITelegramCommand> all =
            Reflection.GetInstances<ITelegramCommand>(Reflection.GetAllTypesImplemented<ITelegramCommand>());

        public static ITelegramCommand Get(string commandText)
        {
            var command = all.FirstOrDefault(q => new Regex(q.CommandRegex).IsMatch(commandText));
            var defaultCommand = new DefaultCommand();
            return command ?? defaultCommand;
        }
    }
}