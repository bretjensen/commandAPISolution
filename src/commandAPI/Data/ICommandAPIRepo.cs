using System.Collections.Generic;
using CommandAPI.Models;

namespace CommandApi.Data {
    public interface ICommandAPIRepo {
        bool SaveChanges ();

        IEnumerable<Command> GetAllCommands ();
        Command GetCommandById (int id);
        void CreateCommand (Command cmd);
        void UpdateCommand (Command cmd);
        void DeleteCommand (Command cmd);
    }
}