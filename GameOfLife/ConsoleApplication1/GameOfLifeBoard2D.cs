using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class GameOfLifeBoard2D: iGameOfLifeBoard
    {
        private GamePiece[,] board;

        private const PieceState offBoardPieceState = PieceState.Dead;

        private const int xDimension = 0;
        private const int yDimension = 1;

        public void Print(TextWriter writer)
        {
            for (int x = 0; x < board.GetLength(xDimension); x++)
            {
                string rowString = string.Empty;
                for (int y = 0; y < board.GetLength(yDimension); y++)
                {
                    rowString += board[x, y].ToString();
                }
                writer.WriteLine(rowString);
            }
        }

        public GameOfLifeBoard2D(StreamReader reader)
        {
            CreateBoard(reader);
        }
        public GameOfLifeBoard2D(List<String> lines)
        {
            CreateBoard(lines);
        }

        private void CreateBoard(StreamReader reader)
        {
            String line;
            List<String> lines = new List<String>();
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }
            CreateBoard(lines);
        }

        private void CreateBoard(List<String> lines)
        {
            board = new GamePiece[lines.Count, LengthOfLongestItem(lines)];
            String[] lineArray = lines.ToArray();

            for (int x = 0; x < board.GetLength(xDimension); x++)
            {
                for (int y = 0; y < board.GetLength(yDimension); y++)
                {
                    if (lineArray[x].Length > y)
                    {
                        board[x, y] = new GamePiece(lineArray[x][y]);
                    }
                    else
                    {
                        board[x, y] = new GamePiece();
                    }
                }
            }
        }

        private int LengthOfLongestItem(List<String> lines)
        {
            int max = 0;
            foreach (String line in lines)
            {
                if (line.Length > max)
                {
                    max = line.Length;
                }
            }
            return max;
        }

        public void Tick()
        {
            PrepareForTick();
            for (int x = 0; x < board.GetLength(xDimension); x++)
            {
                for (int y = 0; y < board.GetLength(yDimension); y++)
                {
                    board[x, y].Tick();
                }
            }
        }
        private void PrepareForTick()
        {
            for (int x = 0; x < board.GetLength(xDimension); x++)
            {
                for (int y = 0; y < board.GetLength(yDimension); y++)
                {
                    board[x, y].Evaluate(CountLivingNeighbors(x, y));
                }
            }
        }

        private int CountLivingNeighbors(int xPosition, int yPosition)
        {
            int count = 0;
            for (int xOffset = -1; xOffset <= 1; xOffset++)
            {
                for (int yOffset = -1; yOffset <= 1; yOffset++)
                {
                    if (safePieceCheck(xOffset + xPosition, yOffset + yPosition) == PieceState.Alive)
                    {
                        count++;
                    }
                }
            }

            if (safePieceCheck(xPosition, yPosition) == PieceState.Alive)
            {
                count--;
            }

            return count;
        }

        private PieceState safePieceCheck(int x, int y)
        {
            try
            {
                return board[x, y].CurrentState;
            }
            catch (IndexOutOfRangeException)
            {
                return offBoardPieceState;
            }
        }
    }
}