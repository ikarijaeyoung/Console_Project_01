namespace _0325_Practice_Inheritance
{
    internal class Program
    {
        public abstract class Pockemon()
        {
            public string name;
            public string skill;
            public abstract void Skill(); // 추상화
        }

        public class Charmander : Pockemon
        {
            public Charmander()
            {
                name = "파이리";
                skill = "불꽃세례";
            }
            public override void Skill()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{name} {skill}!");
                Console.ResetColor();
            }
        }
        public class Squirtle : Pockemon
        {
            public Squirtle()
            {
                name = "꼬부기";
                skill = "물대포";
            }
            public override void Skill()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{name} {skill}!");
                Console.ResetColor();
            }
        }
        public class Bulbasaur : Pockemon
        {
            public Bulbasaur()
            {
                name = "이상해씨";
                skill = "덩굴채찍";
            }
            public override void Skill()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{name} {skill}!");
                Console.ResetColor();
            }
        }
        public class Magikarp : Pockemon
        {
            public Magikarp()
            {
                name = "잉어킹";
                skill = "튀어오르기";
            }
            public override void Skill()
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"{name} {skill}!");
                Console.ResetColor();
                Console.WriteLine("아무일도 일어나지 않았다...");
            }
        }
        public class Pikachu : Pockemon
        {
            public Pikachu()
            {
                name = "피카츄";
                skill = "10만볼트";
            }
            public override void Skill()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{name} {skill}!");
                Console.ResetColor();
            }
        }
        public class Bellsprout : Pockemon
        {
            public Bellsprout()
            {
                name = "모다피";
                skill = "독가루";
            }
            public override void Skill()
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{name} {skill}!");
                Console.ResetColor();
            }
        }
        public class Trainer()
        {

        }

        static void Main(string[] args)
        {

        }
    }
}
