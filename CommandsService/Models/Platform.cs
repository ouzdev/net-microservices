using System.Collections;
using System.Collections.Generic;

namespace CommandsService.Models
{
    public class Platform
    {
        public int Id { get; set; }
        public int ExtarnalID { get; set; }
        public string Name { get; set; }

        public ICollection<Command> Commands { get; set; } = new List<Command>();

    }
}