namespace _250317
{

    /* 1.Item 구조체
    내부에 아래와 같은 데이터를 가진다
    아이템 이름
    아이템 고유 ID
    */
    struct Item
    {
        public string name;
        public int id;
    }


    /*
     * 2.  Inventory 구조체
        내부에 아래와 같은 데이터와 기능을 가진다
        Item 구조체를 보관할 수 있는 배열
        인벤토리 생성 후 내부에서 관리하는 인벤토리의 배열에 대한 크기를 지정할 수 있어야 한다.
    */
    struct Inventory
    {
        public Item[] items;
        public int size;
        
        public void InvenSize(int size)
        {
            this.size = size;
            items = new Item[size];
        }

        public bool AddItem(Item item) 
        { 
            for(int i = 0; i < items.Length; i++) 
            {
                if (items[i].name == null)
                {
                    items[i] = item;
                    return true;
                }
            }
            Console.WriteLine("인벤토리가 꽉 찼습니다. 더이상 아이템 추가가 안됩니다.");
            return false;
        }
    }

    internal class Program
    {
        /*
        3. 메인 함수를 포함하고 있는 클래스에 함수 추가
        Item 구조체를 입력 받아 이름과 고유 ID를 콘솔에 출력하는 함수 제작
        Inventory 구조체를 입력받아 가지고 있는 아이템을 한줄에 하나씩 전부 출력하는 함수 제작
        */
        static void ConsoleItem(Item item)
        {
            Console.WriteLine($"아이템의 이름 : {item.name} 아이템의 아이디 : {item.id}");
        }

        static void ConsoleInventory(Inventory inven)
        {
            Console.WriteLine("인벤토리 목록을 출력합니다.");
            foreach(Item item in inven.items)
            {
                if(item.name != null)
                {
                    Console.WriteLine($"아이템의 이름 : {item.name} 아이템의 아이디 : {item.id}가 인벤토리에 있습니다.");
                }
            }
        }

        static void Main(string[] args)
        {
            //item 구조체 관련 변수
            string itemName;
            int itemID;
            bool isSuccess;
            Item customItem;

            //Inventory 구조체 관련 변수
            int invenSize;
            Inventory userInventory = new Inventory();

            //인벤토리 구조체 입력로직
            do
            {
                Console.WriteLine("인벤토리 크기를 입력하세요");
                isSuccess = int.TryParse(Console.ReadLine(), out invenSize);
                
                if(isSuccess)
                {
                    userInventory.InvenSize(invenSize);
                }

            } while (!isSuccess);


            //아이템 입력
            while(true)
            {

                Console.WriteLine("아이템 이름을 입력하세요 : x 입력 시 종료 ...");
                itemName = Console.ReadLine();
                if (itemName == "x" || itemName == "X") break;

                Console.WriteLine("아이템 아이디를 입력하세요");
                isSuccess = int.TryParse(Console.ReadLine(), out itemID);

                if (isSuccess)
                {
                    customItem.name = itemName;
                    customItem.id = itemID;

                    if(!userInventory.AddItem(customItem))
                    {
                        break;
                    }
                    ConsoleItem(customItem);
                }
            }
                

            ConsoleInventory(userInventory);

        }
    }
}
