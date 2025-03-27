namespace _0327_delegate_Practice
{
    internal class Program
    {
        // 플레이어는 갑옷을 가지고 있다.
        // 플레이어는 갑옷을 착용하는 기능이 있다.
        // 플레이어는 갑옷을 탈착하는 기능이 있다.
        // 갑옷은 내구도를 가지고 있다.
        // 플레이어가 데미지 받을 때, 갑옷은 내구도 1 잃는다.
        // 갑옷이 내구도를 모두 잃어 파괴됐을 때, 플레이어는 갑옷이 벗겨짐

        // +) 플레이어가 공격시 동시에 라이트닝을 앞으로 쏘는 장신구 만들기

        public class Player
        {
            private int hp = 100;
            private int defense = 10;

            // 플레이어는 갑옷을 가지고 있다. ( has - a 관계 )
            public Armor armor;

            public event Action OnTakeDamaged;

            public void TakeDamage(int damage)
            {
                int totalDamage = defense > damage ? 0 : damage - defense;
                hp -= totalDamage;

                OnTakeDamaged.Invoke();
            }

            // 착용
            public void Equip(Armor armor)
            {
                Console.WriteLine("플레이어가 장비를 착용합니다.");
                this.armor = armor;
                defense += armor.Defense;
                Console.WriteLine("플레이어의 방어력이 {0} 이 되었습니다.", defense);

                OnTakeDamaged += armor.TakeDamage;
                armor.OnBreaked += UnEquip;
            }

            // 해제
            public void UnEquip()
            {
                if (armor != null)
                {
                    Console.WriteLine("플레이어가 장비를 해제합니다.");
                    armor.OnBreaked -= UnEquip;
                    OnTakeDamaged -= armor.TakeDamage;


                    defense -= armor.Defense;
                    this.armor = null;
                    Console.WriteLine("플레이어의 방어력이 {0} 이 되었습니다.", defense);
                }
            }


        }

        public class Armor
        {
            // 내구도 
            private int durability = 3;
            private int defense = 10;

            public int Defense { get { return defense; } private set { defense = value; } }

            public event Action OnBreaked;
            public void TakeDamage()
            {
                Console.WriteLine("장비가 내구도가 닳습니다.");
                durability--;
                Console.WriteLine("장비의 내구도가 {0} 이 되었습니다.", durability);
                if (durability <= 0)
                {
                    Break();
                }
            }

            private void Break()
            {
                Console.WriteLine("갑옷 부셔짐");

                OnBreaked.Invoke();
            }
        }


        static void Main(string[] args)
        {
            Player player = new Player();
            Armor armor = new Armor();

            player.Equip(armor);

            player.TakeDamage(1);
            player.TakeDamage(1);
            player.TakeDamage(1);
            player.TakeDamage(1);
            player.TakeDamage(1);
            player.TakeDamage(1);
        }
    }
}
