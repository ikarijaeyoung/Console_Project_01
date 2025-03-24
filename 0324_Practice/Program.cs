using System.ComponentModel;

namespace _0324_Practice
{
    internal class Program
    {
        public class Trainer
        {
            
            PrintPlayerName();

            // 몬스터를 보관할 수 있는 크기 6의 배열
            Monster[] monsters = new Monster[6];

            Monster monster1 = new Monster("이름1", 1);
            Monster monster2 = new Monster("이름2", 2);
            Monster monster3 = new Monster("이름3", 3);
            Monster monster4 = new Monster("이름4", 4);
            Monster monster5 = new Monster("이름5", 5);
            Monster monster6 = new Monster("이름6", 6);  // 기능 구현 먼저 확인하고, 몬스터 이름이나 레벨 디자인 하고싶음
            Add(Monster monster, Monster[] monsters);

            Remove(Monster[] monsters, Monster monster);

            PrintAll(Monster monster, Monster[] monsters);
        }

        // 이름 : 플레이어 이름, 프로그램 시작 시 입력하도록 구현
        static void PrintPlayerName()
        {
            Console.Write("이름을 입력해 주세요 : ");
            string playerName = Console.ReadLine();
            Console.WriteLine($"이름 : {playerName}");
        }

        // 매개변수로 몬스터를 하나 입력받아 배열의 빈 자리에 추가
        static void Add(Monster monster, Monster[] monsters)
        {
            for (int i = 0; i < monsters.Length; i++)
            {
                if (monsters[i] == null)
                {
                    monsters[i] = monster;
                    Console.WriteLine($"{monsters.name}이(가) 추가되었습니다.");
                    return;
                }
            }
            // 빈 자리가 없다면 추가되지 않음
            Console.WriteLine("공간이 부족합니다.");
        }

        static void Remove(Monster[] monsters, Monster monster)
        {
            // 매개변수로 몬스터를 하나 입력받아 동일한 이름을 가진 몬스터를 배열에서 삭제
            for (int i = 0; i < monsters.Length; i++)
            {
                if (monsters[i] != null && monsters[i] == Monster.name)
                {
                    monsters[i] = null;
                    Console.WriteLine($"{monsters.name}이(가) 삭제됩니다.");
                    
                }
                // 이름에 해당하는 몬스터가 없거나 배열에 몬스터가 한마리도 없는 경우 아무 기능도 수행하지 않음.
                
            }
            

        }

        // 자신이 가지고 있는 모든 포켓몬에 대한 정보를 출력
        static void PrintAll(Monster monster, Monster[] monsters)
        {
            foreach (Monster monster in monsters)
            {
                Console.WriteLine($"몬스터 이름 : {monsters.name}\t레벨 : {monsters.level}");
            }
        }



        public class Monster
        {
            string _monsterName;
            int _monsterLevel;

            public Monster(string monsterName, int monsterLevel)
            {
                _monsterName = monsterName;
                _monsterLevel = monsterLevel;

            }

            Print();
        }

        static void Print(Monster _monsterName, Monster _monsterLevel)
        {
            // 자신(몬스터)에 대한 정보를 출력
            Console.WriteLine($"몬스터 이름 : {_monsterName}\t레벨 : {_monsterLevel}");
        }



        static void Main(string[] args)
        {
            // 모르는게 너무 많습니다...
        }
    }
}
