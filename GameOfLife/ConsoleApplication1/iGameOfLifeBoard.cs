using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    interface iGameOfLifeBoard
    {
        void Tick();
        void Print(TextWriter writer);
    }
}
