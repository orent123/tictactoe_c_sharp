using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOBoard
{
    class XOBoard
    {
        private static char player1 = 'X'; //PLAYER 1
        private static char player2 = 'O'; //PLAYER 2
        private static int choice = 0; //INITIALIZE VARIABLE : 0 FIRST PLAYER : 2 SECOND PLAYER
        private static char[,] boardval = new char[3, 3]; //ARRAY 3*3


        static void Main(string[] args)
        {
            int i = 0; // WE FILL THE ARRAY WITH NO DATA AT FIRST TIME JUST WITH SPACE THAT MEAN THAT POSITION IS occupied :
            boardval[0, 0] = ' ';
            boardval[0, 1] = ' ';
            boardval[0, 2] = ' ';
            boardval[1, 0] = ' ';
            boardval[1, 1] = ' ';
            boardval[1, 2] = ' ';
            boardval[2, 0] = ' ';
            boardval[2, 1] = ' ';
            boardval[2, 2] = ' ';
            XOBoard.display();
            string move;
            string s;
            double result;
            while (i < 9)
            {
                
                if (choice == 0)//AT FIRST TIME INIT CHOICE =0 
                {
                REPEATE1:
                    Console.WriteLine("Please enter player 1 move: ");
                    move = Console.ReadLine();
                    try //HANDLE ERROR ON TRY PUT X ON 0
                    {
                        s = XOBoard.put(move);
                        ProcessError(s);
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine("{0} Exception caught.", e.Message);
                        goto REPEATE1;
                    }

                    // XOBoard.put(move);
                    XOBoard.display();
                    result = XOBoard.status('X',i);
                    if (result == 9) // IF RESAULT = 9 EXIT
                    {
                        i = 9;
                    }
                    i++;
                    choice++;
                }
                else
                {
                REPEATE2: //IN CASE OF TRING INPUR DATA IN BLOCK CELL
                    Console.WriteLine("Please enter player 2 move: ");
                    move = Console.ReadLine();
                    
                    try //HANDLE ERROR ON TRY PUT 0 ON X
                    {
                       s = XOBoard.put(move);
                       ProcessError(s);
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine("{0} Exception caught.", e.Message);
                        goto  REPEATE2;
                    }
                    XOBoard.display();
                    result = XOBoard.status('O',i);
                    if (result == 9) // IF RESAULT = 9 EXIT
                    {
                        i = 9;
                    }
                    i++;
                    choice--; //BACK TO PLAYER 1

                }
                
            }
          
            Console.ReadKey();
        }
        static void ProcessError(string s)
        {
            if (s != "")
            {
                string message = "THIS CELL IS BLOCKED PLS CHOOSE ANOTHER POSITION";
                throw new CellErrorException(message);//WE RAISE ERROR TO CUSTOM CLASS
            }
        }
        public static int status(char val, int i)//CHECK IF WIN OR NOT YET WIN
        {

            int z;
            z = 0; //intialize
            if (boardval[0, 0] == boardval[0, 1] && boardval[0, 0] == boardval[0, 2])
            {
                val = boardval[0, 0];
                if (val != ' ')
                {
                    Console.WriteLine("Winner is {0}", val);
                    z = 9;
                    return z;

                }
            }

            else if (boardval[1, 0] == boardval[1, 1] && boardval[1, 0] == boardval[1, 2])
            {
                val = boardval[1, 0];
                if (val != ' ')
                {
                    Console.WriteLine("Winner is {0}", val);
                    z = 9;
                    return z;

                }
            }
            else if (boardval[2, 0] == boardval[2, 1] && boardval[2, 0] == boardval[2, 2])
            {
                val = boardval[2, 0];
                if (val != ' ')
                {

                    Console.WriteLine("Winner is {0}", val);
                    z = 9;
                    return z;
                }
            }
            else if (boardval[0, 0] == boardval[1, 0] && boardval[0, 0] == boardval[2, 0])
            {
                val = boardval[0, 0];
                if (val != ' ')
                {
                    Console.WriteLine("Winner is {0}", val);
                    z = 9;
                    return z;
                }
            }
            else if (boardval[0, 1] == boardval[1, 1] && boardval[0, 1] == boardval[2, 1])
            {
                val = boardval[0, 1];
                if (val != ' ')
                {
                    Console.WriteLine("Winner is {0}", val);
                    z = 9;
                    return z;
                }
            }
            else if (boardval[0, 2] == boardval[1, 2] && boardval[0, 2] == boardval[2, 2])
            {
                val = boardval[0, 2];
                if (val != ' ')
                {
                    Console.WriteLine("Winner is {0}", val);
                    z = 9;
                    return z;
                }
            }
            else if (boardval[0, 0] == boardval[1, 1] && boardval[0, 0] == boardval[2, 2])
            {
                val = boardval[0, 0];
                if (val != ' ')
                {
                    Console.WriteLine("Winner is {0}", val);
                    z = 9;
                    return z;
                }

            }
            else if (boardval[0, 2] == boardval[1, 1] && boardval[0, 2] == boardval[2, 0])
            {
               
                val = boardval[0, 2];
                if (val != ' ')
                {
                    Console.WriteLine("Winner is {0}", val);
                    z = 9;
                    return z;
                }

            }
            else
            {

                if (z == 0 && i == 8)
                {
                    Console.WriteLine("No Winner");
                    return z;
                }
            }
            return z;
        }

       




        public static void display() // FILL  THE GAME WITH THE ARRAY RESAULT
        {
            Console.Clear();
            Console.WriteLine("    A        B         C  ");
            Console.WriteLine("        |        |        |   ");
            Console.WriteLine(" {0}      |  {1}     |  {2}     | {3} ", boardval[0, 0], boardval[0, 1], boardval[0, 2],1) ;
            Console.WriteLine("________|________|________|");
            Console.WriteLine("        |        |        |    ");
            Console.WriteLine(" {0}      |  {1}     |  {2}     | {3} ", boardval[1, 0], boardval[1, 1], boardval[1, 2],2);
            Console.WriteLine("________|________|________|");
            Console.WriteLine("        |        |        |");
            Console.WriteLine(" {0}      |  {1}     |  {2}     | {3} ", boardval[2, 0], boardval[2, 1], boardval[2, 2],3);


        }
        public static string  put(String move) // WE PUT THE INPUT OF THE PLAYER INTO ARRAY
        {
            string returnVal = "";
            if (move == "A1")
            {
                if (choice == 0 && boardval[0, 0] == ' ') //WE CHECK THAT CELL IS NOT BLOCK YET 
                {
                    boardval[0, 0] = player1;
                    return returnVal;
                }
                else if (boardval[0, 0] == ' ')
                {
                    boardval[0, 0] = player2;
                    return returnVal;
                }
                else
                {
                    returnVal = "Invalid Attempt";
                    return returnVal;
                }
            }
            else if (move == "A2")
            {
                if (choice == 0 && boardval[1, 0] == ' ')
                {
                    boardval[1, 0] = player1;
                    return returnVal;

                }
                else if (boardval[1, 0] == ' ')
                {
                    boardval[1, 0] = player2;
                    return returnVal;
                }
                else
                {
                    returnVal = "Invalid Attempt";
                    return returnVal;
                }
            }
            else if (move == "A3")
            {
                if (choice == 0 && boardval[2, 0] == ' ')
                {
                    boardval[2, 0] = player1;
                    return returnVal;
                }
                else if (boardval[2, 0] == ' ')
                {
                    boardval[2, 0] = player2;
                     return returnVal;  
                }
                else
                {
                    returnVal = "Invalid Attempt";
                    return returnVal;
                }
            }
            else if (move == "B1")
            {
                if (choice == 0 && boardval[0, 1] == ' ')
                {
                    boardval[0, 1] = player1;
                    return returnVal;

                }
                else if (boardval[0, 1] == ' ')
                {
                    boardval[0, 1] = player2;
                    return returnVal;
                }
                else
                {
                    returnVal = "Invalid Attempt";
                    return returnVal;
                }
            }
            else if (move == "B2")
            {
                if (choice == 0 && boardval[1, 1] == ' ')
                {
                    boardval[1, 1] = player1;
                    return returnVal;

                }
                else if (boardval[1, 1] == ' ')
                {
                    boardval[1, 1] = player2;
                    return returnVal;
                }
                else
                {
                    returnVal = "Invalid Attempt";
                    return returnVal;
                }
            }
            else if (move == "B3")
            {
                if (choice == 0 && boardval[2, 1] == ' ')
                {
                    boardval[2, 1] = player1;
                    return returnVal;

                }
                else if (boardval[2, 1] == ' ')
                {
                    boardval[2, 1] = player2;
                    return returnVal;
                }
                else
                {
                    returnVal = "Invalid Attempt";
                    return returnVal;
                }
            }
            else if (move == "C1")
            {
                if (choice == 0 && boardval[0, 2] == ' ')
                {
                    boardval[0, 2] = player1;
                    return returnVal;
                }
                else if (boardval[0, 2] == ' ')
                {
                    boardval[0, 2] = player2;
                    return returnVal;
                }
                else
                {
                    returnVal = "Invalid Attempt";
                    return returnVal;
                }
            }
            else if (move == "C2")
            {
                if (choice == 0 && boardval[1, 2] == ' ')
                {
                    boardval[1, 2] = player1;
                    return returnVal;

                }
                else if (boardval[1, 2] == ' ')
                {
                    boardval[1, 2] = player2;
                    return returnVal;
                }
                else
                {
                    return "Invalid Attempt";
                }
            }
            else if (move == "C3")
            {
                if (choice == 0 && boardval[2, 2] == ' ')
                {
                    boardval[2, 2] = player1;
                    return returnVal;

                }
                else if (boardval[2, 2] == ' ')
                {
                    boardval[2, 2] = player2;
                    return returnVal;
                }
                else
                {
                    returnVal= "Invalid Attempt";
                    return returnVal;
                }
            }
            
                    return returnVal;
        }

    }



}
