using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class GameOfLifeBoardFactory
    {
        public iGameOfLifeBoard Create2DBoard(StreamReader reader)
        {
            return new GameOfLifeBoard2D(reader);
        }
        public iGameOfLifeBoard Create3DBoard(StreamReader reader)
        {
            throw new NotImplementedException();
        }
        public iGameOfLifeBoard CreateBoard(StreamReader reader, int dimensions = 2)
        {
            if (dimensions == 2)
            {
                return Create2DBoard(reader);
            }
            if (dimensions == 3)
            {
                return Create3DBoard(reader);
            }
            else
            {
                //TODO: Generalize the game of life for N dimensions
                throw new NotImplementedException();
            }

        }
    }
}
