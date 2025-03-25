using System;

namespace _0325_Practice_Inheritance
{
    internal class Program
    {
        public abstract class Pokemon
        {
            public string name;
            public string skill;
            public abstract void Attack(); // 추상화
        }

        public class Charmander : Pokemon
        {
            public Charmander()
            {
                name = "파이리";
                skill = "불꽃세례";
            }
            public override void Attack()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{name} {skill}!");
                Console.ResetColor();
            }
        }
        public class Squirtle : Pokemon
        {
            public Squirtle()
            {
                name = "꼬부기";
                skill = "물대포";
            }
            public override void Attack()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{name} {skill}!");
                Console.ResetColor();
            }
        }
        public class Bulbasaur : Pokemon
        {
            public Bulbasaur()
            {
                name = "이상해씨";
                skill = "덩굴채찍";
            }
            public override void Attack()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{name} {skill}!");
                Console.ResetColor();
            }
        }
        public class Magikarp : Pokemon
        {
            public Magikarp()
            {
                name = "잉어킹";
                skill = "튀어오르기";
            }
            public override void Attack()
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"{name} {skill}!");
                Console.ResetColor();
                Console.WriteLine("아무일도 일어나지 않았다...");
            }
        }
        public class Pikachu : Pokemon
        {
            public Pikachu()
            {
                name = "피카츄";
                skill = "10만볼트";
            }
            public override void Attack()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{name} {skill}!");
                Console.ResetColor();
            }
        }
        public class Bellsprout : Pokemon
        {
            public Bellsprout()
            {
                name = "모다피";
                skill = "독가루";
            }
            public override void Attack()
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{name} {skill}!");
                Console.ResetColor();
            }
        }
        public class Trainer
        {
            public Pokemon[] pokemons;
            Pokemon currentPokemon;
            public Trainer()
            {
                pokemons = new Pokemon[6];
            }

            public void Pick(int index)
            {
                if (index < 0 || index >= pokemons.Length || pokemons[index] == null)
                {
                    Console.WriteLine("잘못된 값입니다. 다시 입력해주세요.");
                    return;
                }

                currentPokemon = pokemons[index];
                Console.WriteLine($"현재 선택된 포켓몬: {currentPokemon.name}");
            }

            public void Print()
            {
                Console.WriteLine("====== 현재 보유한 몬스터 ======");
                for (int i = 0; i < pokemons.Length; i++)
                {
                    if (pokemons[i] != null)
                    {
                        Console.WriteLine($"\t{i + 1}.{pokemons[i].name}");
                    }
                }
                Console.WriteLine("================================");
            }
        }

        static void Main(string[] args)
        {
            Trainer trainer = new Trainer();
            int index;

            trainer.pokemons[0] = new Charmander();
            trainer.pokemons[1] = new Squirtle();
            trainer.pokemons[2] = new Bulbasaur();
            trainer.pokemons[3] = new Magikarp();
            trainer.pokemons[4] = new Pikachu();
            trainer.pokemons[5] = new Bellsprout();

            trainer.Print();

            Console.Write("포켓몬을 선택해 주세요 : ");
            index = int.Parse(Console.ReadLine());

            trainer.Pick(index - 1);
            trainer.pokemons[index - 1].Attack();

        }
    }
}
