using PhotoStudio.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStudio.DAL.Other
{
    public class Statistic
    {
        public int successful = 0;
        public int failed = 0;
        public int totalmade = 0;

        public Dictionary<Photographer, int> failed_photographers = new Dictionary<Photographer, int>();
        public Dictionary<Photographer, int> successful_photographers = new Dictionary<Photographer, int>();
        public Dictionary<Photographer, int> totalmade_photographers = new Dictionary<Photographer, int>();
    }
}
