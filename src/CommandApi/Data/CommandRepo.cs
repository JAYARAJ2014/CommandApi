using System;
using System.Collections.Generic;
using System.Linq;
using CommandApi.Models;

namespace CommandApi.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly CommandContext _context;

        public CommandRepo(CommandContext context)
        {
            _context = context;
        }
        public void Create(Command cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd));

            _context.CommandItems.Add(cmd);
        }

        public void Delete(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.CommandItems.Remove(cmd);
        }

        public IEnumerable<Command> GetAll()
        {
            return _context.CommandItems.ToList();
        }

        public Command GetById(int id)
        {
            return _context.CommandItems.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            var result = _context.SaveChanges();
            return result >= 0;
        }

        public void Update(Command cmd)
        {

        }
    }
}