namespace _0326_practice_interface
{
    internal class Program
    {

        // 플레이어가 다양한 물체 앞에서 상호작용 키를 누르면 앞 대상에 따라 다양한 반응
        // 상인 NPC는 상점열기 상호작용
        // NPC 앞에선 대화 시작 상호작용
        // 상자 앞에선 아이템 습득 상호작용
        // 문 앞에선 입장 상호작용

        public interface IInteractive
        {
            public void Interaction();
        }

        public class Player
        {
            public void Interaction()
            {
                // 여기를 잘 모르겠음
            }
        }

        public class NonPlayerCharacter : IInteractive
        {
            public virtual void Interaction()
            {
                // 대화하기
                Console.WriteLine("안녕하세요.");
            }
        }

        public class Merchant : NonPlayerCharacter
        {
            public override void Interraction()
            {
                // 상점열기
                Console.WriteLine("상점열기");
            }
        }

        public class Chest : IInteractive
        {
            public void Interaction()
            {
                // 아이템 습득
            }
        }

        public class Door : IInteractive
        {
            public void Interaction()
            {
                // 입장
            }
        }


        static void Main(string[] args)
        {
            NonPlayerCharacter nonPlayerCharacter = new NonPlayerCharacter();
            Merchant merchant = new Merchant();
            Chest chest = new Chest();
            Door door = new Door();

            Player player = new Player();

            player.Interaction(nonPlayerCharacter);
            player.Interaction(merchant);
            player.Interaction(chest);
            player.Interaction(door);
        }
    }
}
