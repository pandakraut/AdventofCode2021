using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class day4_1
    {
        public static List<int> depths = new List<int>();

        static void Main(string[] args)
        {
            List<string> drawList = new List<string>();
            List<KeyValuePair<int, bool>> lineComponents = new List<KeyValuePair<int, bool>>();
            List<List<KeyValuePair<int, bool>>> tempBingo = new List<List<KeyValuePair<int, bool>>>();
            List<bingoBoard> bingoBoardList = new List<bingoBoard>();
            int boardCount = 0;

            foreach (string line in File.ReadLines("../../../InputDay4.txt"))
            {
                if (drawList.Count == 0)
                {
                    drawList = new List<string>(line.Split(','));
                    continue;
                }

                if (line.Length == 0)
                {
                    if (tempBingo.Count > 0)
                    {
                        bingoBoardList.Add(new bingoBoard(boardCount, tempBingo));
                        tempBingo = new List<List<KeyValuePair<int, bool>>>();
                        boardCount++;
                    }
                }
                else
                {
                    lineComponents = new List<KeyValuePair<int, bool>>();
                    foreach (string currentComponent in line.Split(' '))
                    {
                        if (currentComponent.Length > 0)
                        {
                            lineComponents.Add(new KeyValuePair<int, bool>(Convert.ToInt32(currentComponent), false));
                        }
                    }
                    tempBingo.Add(lineComponents);
                }
            }
            bingoBoardList.Add(new bingoBoard(boardCount, tempBingo));

            int bingoId = 0;
            foreach (string currentDraw in drawList)
            {
                int match = Convert.ToInt32(currentDraw);
                bool bingo = false;
                int output = 0;

                foreach (bingoBoard currentBoard in bingoBoardList)
                {
                    bool matchFound = false;
                    for (int i = 0; i < currentBoard.boardValues.Count; i++)
                    {
                        for (int j = 0; j < currentBoard.boardValues[i].Count; j++)
                        {
                            if (match == currentBoard.boardValues[i][j].Key)
                            {
                                matchFound = true;
                                currentBoard.boardValues[i][j] = new KeyValuePair<int, bool>(currentBoard.boardValues[i][j].Key, true);
                                currentBoard.rowMatches[i]++;
                                if (currentBoard.rowMatches[i] == 5)
                                {
                                    bingo = true;
                                }
                                currentBoard.columnMatches[j]++;
                                if (currentBoard.columnMatches[j] == 5)
                                {
                                    bingo = true;
                                }
                                break;
                            }
                        }
                        if (matchFound)
                        {
                            break;
                        }
                    }
                    if (bingo)
                    {
                        bingoId = currentBoard.boardId;
                        for (int i = 0; i < currentBoard.boardValues.Count; i++)
                        {
                            for (int j = 0; j < currentBoard.boardValues[i].Count; j++)
                            {
                                if (!currentBoard.boardValues[i][j].Value)
                                {
                                    output += currentBoard.boardValues[i][j].Key;
                                }
                            }
                        }

                        break;
                    }
                }
                if (bingo)
                {
                    Console.WriteLine("output: " + output * match);
                    break;
                }
            }

        }

        public class bingoBoard
        {
            public int boardId { get; set; }
            public List<List<KeyValuePair<int, bool>>> boardValues { get; set; }
            public List<int> rowMatches { get; set; }
            public List<int> columnMatches { get; set; }

            public bingoBoard(int inputBoardId, List<List<KeyValuePair<int, bool>>> inputBoardValues)
            {
                boardId = inputBoardId;
                boardValues = inputBoardValues;
                rowMatches = new List<int>
                {
                    0,0,0,0,0
                };
                columnMatches = new List<int>
                {
                    0,0,0,0,0
                };
            }
        }
    }
}
