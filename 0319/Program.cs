namespace _0319
{
    internal class Program
    {
        struct Position
        {
            public int x;
            public int y;
        }
        static void Main(string[] args)
        {
            bool gameOver = false;
            char[,] map;
            Position playerPos;

            //게임 시작 화면
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\tB");
            Console.ResetColor();

            Console.Write(" to ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("H");
            Console.ResetColor();

            Console.Write(" Game \nPress any key to start");  //로딩 색처럼 맵에 있는 B랑 H도 색칠하고싶은데, 어떻게 해야할까.

            Console.ReadKey();
            Console.Clear();

            Start(out map, out playerPos);
            while (gameOver == false)
            {
                Render(map, playerPos);
                ConsoleKey key = UserInput();
                Update(ref playerPos, ref map, key, ref gameOver);
            }
            End();
        }
        // 게임 시작 설정
        static void Start(out char[,] map, out Position playerPos)
        {
            Console.CursorVisible = false;

            // 맵 디자인
            map = new char[12, 12]
            {
             { 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W'},
             { 'W', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'W'},
             { 'W', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'W'},
             { 'W', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'W'},
             { 'W', ' ', ' ', ' ', ' ', ' ', ' ', 'W', 'B', 'W', ' ', 'W'},
             { 'W', 'H', 'H', ' ', ' ', ' ', ' ', ' ', 'B', ' ', ' ', 'W'},
             { 'W', 'H', 'H', ' ', ' ', ' ', ' ', 'W', 'B', 'W', ' ', 'W'},
             { 'W', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'B', ' ', ' ', 'W'},
             { 'W', ' ', ' ', ' ', ' ', ' ', ' ', 'W', 'W', 'W', ' ', 'W'},
             { 'W', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'W'},
             { 'W', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'W'},
             { 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W'},
            };

            //캐릭터 스폰 위치 설정
            playerPos.x = 6;
            playerPos.y = 6;
        }

        // 게임 출력 설정
        static void Render(char[,] map, Position playerPos)
        {
            Console.SetCursorPosition(0, 0);
            PrintMap(map);
            PrintRule();
            PrintPlayer(playerPos);
        }
        static void PrintRule()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("W는 벽입니다.\nB를 H에 두면 G가 됩니다.\nB를 전부 G로 만들면 승리!\nB는 두 개 이상 옮길 수 없습니다.");
            Console.WriteLine("========================================");
            Console.WriteLine("재시작 : R\n게임 종료 : ESC");
        }
        static void PrintMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(map[y, x]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        static void PrintPlayer(Position playerPos)
        {
            Console.SetCursorPosition(playerPos.x, playerPos.y);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("p");
            Console.ResetColor();
        }

        // 유저 입력 설정
        static ConsoleKey UserInput()
        {
            return Console.ReadKey(true).Key;
        }

        // 게임 입력 설정
        static void Update(ref Position playerPos, ref char[,] map, ConsoleKey key, ref bool gameOver)
        {
            Move(ref playerPos, ref map, key);

            if (key == ConsoleKey.R) // 게임 재시작 단축키
            {
                FirstStageReset(ref map, ref playerPos);
            }
            if (key == ConsoleKey.Escape) //게임 종료 단축키
            {
                Console.Clear();
                Environment.Exit(0);
            }
            bool isClear = IsClear(map);
            if (isClear)
            {
                gameOver = true;
            }
        }


        // 두번째 스테이지 (만드려 했는데 리셋이랑 move함수를 어떻게 해야하지.. 첫 단추 잘못 잠궈서 다시 풀어야하는 느낌)
        static void SecondStage(ref char[,] map, ref Position playerPos)
        {
            Console.Clear();

        }
        //첫 스테이지 재시작
        static void FirstStageReset(ref char[,] map, ref Position playerPos)

        {
            Console.CursorVisible = false;

            //첫 스테이지 맵 디자인
            map = new char[12, 12]
            {
            { 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W'},
            { 'W', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'W'},
            { 'W', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'W'},
            { 'W', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'W'},
            { 'W', ' ', ' ', ' ', ' ', ' ', ' ', 'W', 'B', 'W', ' ', 'W'},
            { 'W', 'H', 'H', ' ', ' ', ' ', ' ', ' ', 'B', ' ', ' ', 'W'},
            { 'W', 'H', 'H', ' ', ' ', ' ', ' ', 'W', 'B', 'W', ' ', 'W'},
            { 'W', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'B', ' ', ' ', 'W'},
            { 'W', ' ', ' ', ' ', ' ', ' ', ' ', 'W', 'W', 'W', ' ', 'W'},
            { 'W', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'W'},
            { 'W', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'W'},
            { 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W'},
            };

            //캐릭터 스폰 위치 설정
            playerPos.x = 6;
            playerPos.y = 6;
        }


        // 유저 입력에 따른 플레이어 이동
        static void Move(ref Position playerPos, ref char[,] map, ConsoleKey key)
        {
            Position targetPos; // 다음에 플레이어가 찍힐 곳
            Position overPos; // 다음에 플레이어가 찍힐 곳 그 다음 좌표

            // 유저 입력에 따라 플레이어 좌표 이동
            switch (key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    targetPos.y = playerPos.y - 1;
                    targetPos.x = playerPos.x;
                    overPos.y = playerPos.y - 2;
                    overPos.x = playerPos.x;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    targetPos.y = playerPos.y + 1;
                    targetPos.x = playerPos.x;
                    overPos.y = playerPos.y + 2;
                    overPos.x = playerPos.x;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    targetPos.x = playerPos.x - 1;
                    targetPos.y = playerPos.y;
                    overPos.x = playerPos.x - 2;
                    overPos.y = playerPos.y;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    targetPos.x = playerPos.x + 1;
                    targetPos.y = playerPos.y;
                    overPos.x = playerPos.x + 2;
                    overPos.y = playerPos.y;
                    break;
                default:
                    return;
            }

            // 움직이는 방향에 볼이 있을 때
            if (map[targetPos.y, targetPos.x] == 'B')
            {
                // 그 다음 위치가 구멍이 있을 때
                if (map[overPos.y, overPos.x] == 'H')
                {
                    // 구멍위치에 골인표시
                    map[overPos.y, overPos.x] = 'G';
                    // 볼 위치를 빈칸으로
                    map[targetPos.y, targetPos.x] = ' ';
                    // 플레이어 이동
                    playerPos.y = targetPos.y;
                    playerPos.x = targetPos.x;
                }
                // 그 다음 위치가 빈 칸일 때
                else if (map[overPos.y, overPos.x] == ' ')
                {
                    // 그 위치에 볼을 입력
                    map[overPos.y, overPos.x] = 'B';
                    // 볼 위치를 빈칸으로
                    map[targetPos.y, targetPos.x] = ' ';
                    // 플레이어 이동
                    playerPos.y = targetPos.y;
                    playerPos.x = targetPos.x;
                }
                // 그 다음 위치가 벽
                else if (map[overPos.y, overPos.x] == 'W')
                {
                    //아무것도 안 함
                }
                // 그 다음 위치가 볼
                else if (map[overPos.y, overPos.x] == 'B')
                {
                    //아무것도 안 함
                }

            }
            // 움직이는 방향에 골인이 있을 때
            else if (map[targetPos.y, targetPos.x] == 'G')
            {
                // 그 다음 위치가 또 다른 홀이 있을 때
                if (map[overPos.y, overPos.x] == 'H')
                {
                    // 볼을 옮긴것으로 취급해 골 표시
                    map[overPos.y, overPos.x] = 'G';
                    // 골인을 홀로 표시
                    map[targetPos.y, targetPos.x] = 'H';
                    // 플레이어 이동
                    playerPos.y = targetPos.y;
                    playerPos.x = targetPos.x;
                }
                // 그 다음 위치가 빈 칸일 때
                else if (map[overPos.y, overPos.x] == ' ')
                {
                    // 볼을 빼내어 빈칸에 볼을 옮김
                    map[overPos.y, overPos.x] = 'B';
                    // 골인을 홀로 표시
                    map[targetPos.y, targetPos.x] = 'H';
                    // 플레이어 이동
                    playerPos.y = targetPos.y;
                    playerPos.x = targetPos.x;
                }
                else if (map[overPos.y, overPos.x] == 'W')
                {
                    //아무것도 안 함
                }
                else if (map[overPos.y, overPos.x] == 'B')
                {
                    //아무것도 안 함
                }
            }
            // 움직이는 방향에 홀이 있을 때
            else if (map[targetPos.y, targetPos.x] == 'H')
            {
                //플레이어 이동
                playerPos.y = targetPos.y;
                playerPos.x = targetPos.x;
            }
            // 움직이는 방향이 빈 칸일 때
            else if (map[targetPos.y, targetPos.x] == ' ')
            {
                // 플레이어 이동
                playerPos.y = targetPos.y;
                playerPos.x = targetPos.x;
            }
            // 움직이려는 방향이 벽일 때
            else if (map[targetPos.y, targetPos.y] == 'W')
            {
                //아무것도 안 함
            }

        }

        // 게임 클리어 조건
        static bool IsClear(char[,] map)
        {
            int goalCount = 0;

            // 맵에서 H글자를 찾을때 마다 골 카운트 1 증가
            foreach (char tile in map)
            {
                if (tile == 'H')
                {
                    goalCount++;
                    break;
                }
            }

            // H가 없으면 클리어
            if (goalCount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // 게임 끝 
        static void End()
        {
            Console.Clear();
            Console.WriteLine("==============================\n축하드립니다.\n게임을 클리어 하셨습니다.\n==============================");
        }
    }

}
