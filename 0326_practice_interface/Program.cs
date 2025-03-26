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
            public void interaction();
        }

        public class Player
        {
            public void Interaction()
            {

            }
        }

        public class NonPlayerCharacter : IInteractive
        {
            public void interaction()
            {
                // 대화하기
            }
        }

        public class Merchant : NonPlayerCharacter
        {
            public void Interraction()
            {
                // 상점열기
            }
        }

        public class Chest : IInteractive
        {
            public void interaction()
            {
                // 아이템 습득
            }
        }

        public class Door : IInteractive
        {
            public void interaction()
            {
                // 입장
            }
        }


        static void Main(string[] args)
        {
            
        }
    }
}
