using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace TextRPG
{
    internal class Program
    {
        static string[] everyItem = new string[7]
            { "수련자 갑옷  | 방어력 + 5 | 수련에 도움을 주는 갑옷입니다.",
            "무쇠갑옷  | 방어력 + 9 | 무쇠로 만들어져 튼튼한 갑옷입니다.",
            "스파르타의 갑옷 | 방어력 + 15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다." ,
            "낡은 검 | 공격력 + 2 | 쉽게 볼 수 있는 낡은 검 입니다.",
            "청동 도끼 | 공격력 +5 | 어디선가 사용됐던거 같은 도끼입니다.",
            "스파르타의 창 | 공격력 +7 | 스파르타의 전사들이 사용했다는 전설의 창입니다.",
            "삼위일체 | 공격력 + 15 | 방어력 + 20 | 공 방 일 체 " };
        static string[] possessionItem = new string[7];
        static bool[] EquippedItem = { false, false, false, false, false, false, false };
        static int[] everyItemGold = { 1000, 1800, 3500, 600, 1500, 2700, 5000 };
        static int[] buyItemGold = new int[7];
        static bool[] buyItemCHK = { false, false, false, false, false, false, false };

        static int[,] ItemStats = new int[7, 2] { { 0, 5 }, { 0, 9 }, { 0, 15 }, { 2, 0 }, { 5, 0 }, { 7, 0 }, { 15, 15 } };
        static int[,] MyStats = new int[7, 2];

        static string Name;
        static string Chad;

        static float AttackPower = 10f;
        static float DefensePower = 5;  

        static int Hp = 100;
        static int Gold = 1500;
        static int buyCNT = 0;
        static int APP = 0;
        static int DPP = 0;
        static int Level = 01;
        static int claerCount = 0;

        static bool fail = false;

        static void Main(string[] args)
        {
            NewStart();
            StartScreen();
        }

        // 시작 화면
        static public void StartScreen()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("4. 던전입장");
                Console.WriteLine("5. 휴식하기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요");
                Console.Write(">> ");
                try { 
                int Choice = int.Parse(Console.ReadLine());
                if (Choice == 1)
                {
                    StatusWindow();
                }
                else if (Choice == 2)
                {
                    Inventory();
                }
                else if (Choice == 3)
                {
                    Store();
                }
                else if (Choice == 4)
                {
                    Dungeon();
                }
                else if (Choice == 5)
                {
                    Rest();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadKey();
                }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("잘못된 입력입니다.", ex.Message);
                    Console.ReadKey();
                }
            }
        }

        // 상태창
        static public void StatusWindow()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine();
                Console.WriteLine("이름 : {0}", Name);
                Console.WriteLine("LV {0}", Level);
                Console.WriteLine("Chad ( {0} )", Chad);
                if (APP > 0)
                {
                    Console.WriteLine("공격력 :  {0}(+{1})", AttackPower, APP);
                }
                else
                {
                    Console.WriteLine("공격력 :  {0}", AttackPower);
                }
                if (DPP > 0)
                {
                    Console.WriteLine("방어력 :  {0}(+{1})", DefensePower, DPP);
                }
                else
                {
                    Console.WriteLine("방어력 :  {0}", DefensePower);
                }
                Console.WriteLine("체 력 :  {0}", Hp);
                Console.WriteLine("Gold :  {0} G", Gold);
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                try { 
                int Choice = int.Parse(Console.ReadLine());
                if (Choice == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadKey();
                }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("잘못된 입력입니다.", ex.Message);
                    Console.ReadKey();
                }

            }
        }


        // 인벤토리
        static public void Inventory()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                for (int i = 0; i < possessionItem.Length; i++)
                {
                    if (possessionItem?[i] != null)
                    {
                        Console.WriteLine("- {0}", possessionItem[i]);
                    }
                }
                Console.WriteLine();
                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요");
                Console.Write(">> ");
                try
                {
                    int Choice = int.Parse(Console.ReadLine());
                    // 장착 관리
                    if (Choice == 1)
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("인벤토리 - 장착 관리");
                            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                            Console.WriteLine();
                            Console.WriteLine("[아이템 목록]");
                            for (int i = 0; i < possessionItem.Length; i++)
                            {
                                if (possessionItem?[i] != null)
                                {
                                    Console.WriteLine("- {0} {1}", i + 1, possessionItem[i]);
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine("0. 나가기");
                            Console.WriteLine();
                            Console.WriteLine("원하시는 행동을 입력해주세요");
                            Console.Write(">> ");
                            int Index = int.Parse(Console.ReadLine()) - 1;
                            if (Index <= possessionItem.Length && Index >= 0)
                            {
                                if (EquippedItem[Index] != true)
                                {
                                    Equipped(Index);
                                    for (int i = 0; i < possessionItem.Length; i++)
                                    {
                                        if (possessionItem[Index] == possessionItem[i]) continue;
                                        if (EquippedItem[i] == true && MyStats[i, 0] > 0 && MyStats[Index, 0] > 0) // 무기
                                        {
                                            int startIdx = possessionItem[i].IndexOf("]");
                                            possessionItem[i] = possessionItem[i].Substring(startIdx + 1);
                                            EquippedItem[i] = false;
                                            AttackPower -= MyStats[i, 0];
                                            APP -= MyStats[i, 0];
                                            if (MyStats[i, 0] > 0)
                                            {
                                                DefensePower -= MyStats[i, 1];
                                                DPP -= MyStats[i, 1];
                                            }
                                        }
                                        else if (EquippedItem[i] == true && MyStats[i, 1] > 0 && MyStats[Index, 1] > 0) // 방어구
                                        {
                                            int startIdx = possessionItem[i].IndexOf("]");
                                            possessionItem[i] = possessionItem[i].Substring(startIdx + 1);
                                            EquippedItem[i] = false;
                                            DefensePower -= MyStats[i, 1];
                                            DPP -= MyStats[i, 1];
                                            if (MyStats[i, 0] > 0)
                                            {
                                                AttackPower -= MyStats[i, 0];
                                                APP -= MyStats[i, 0];
                                            }
                                        }
                                        else if (EquippedItem[i] == true && MyStats[i, 0] > 0 && MyStats[i, 1] > 0) // 공+방
                                        {
                                            int startIdx = possessionItem[i].IndexOf("]");
                                            possessionItem[i] = possessionItem[i].Substring(startIdx + 1);
                                            EquippedItem[i] = false;
                                            AttackPower -= MyStats[i, 0];
                                            DefensePower -= MyStats[i, 1];
                                            APP -= MyStats[i, 0];
                                            DPP -= MyStats[i, 1];
                                        }
                                    }
                                }
                                else
                                {
                                    Release(Index);
                                }
                            }
                            else if (Index == -1)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("잘못된 입력입니다.");
                                Console.ReadKey();
                            }
                        }
                    }
                    else if (Choice == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("잘못된 입력입니다.", ex.Message);
                    Console.ReadKey();
                }
            }
        }

        // 상점
        static public void Store()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine();
                Console.WriteLine("[보유 골드]");
                Console.WriteLine("{0} G", Gold);
                Console.WriteLine();
                Console.WriteLine("[아이템 목록");
                for (int i = 0; i < everyItem.Length; i++)
                {
                    if (buyItemCHK[i] == true)
                    {
                        Console.WriteLine("- {0} | 구매완료", everyItem[i]);
                    }
                    else
                    {
                        Console.WriteLine("- {0} | {1} G", everyItem[i], everyItemGold[i]);
                    }
                }
                Console.WriteLine();
                Console.WriteLine("1. 아이템 구매");
                Console.WriteLine("2. 아이템 판매");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요");
                Console.Write(">> ");
                try
                {
                    int Choice = int.Parse(Console.ReadLine());
                    //아이템 구매
                    if (Choice == 1)
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("상점 - 아이템 구매");
                            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                            Console.WriteLine();
                            Console.WriteLine("[보유 골드]");
                            Console.WriteLine("{0} G", Gold);
                            Console.WriteLine();
                            Console.WriteLine("[아이템 목록");
                            for (int i = 0; i < everyItem.Length; i++)
                            {
                                if (buyItemCHK[i] == true)
                                {
                                    Console.WriteLine("- {0} {1} | 구매완료", i + 1, everyItem[i]);
                                }
                                else
                                {
                                    Console.WriteLine("- {0} {1} | {2} G", i + 1, everyItem[i], everyItemGold[i]);
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine("0. 나가기");
                            Console.WriteLine();
                            Console.WriteLine("원하시는 행동을 입력해주세요");
                            Console.Write(">> ");
                            int Index = int.Parse(Console.ReadLine()) - 1;
                            if (Index <= everyItem.Length && Index >= 0)
                            {
                                if (buyItemCHK[Index] == true)
                                {
                                    Console.WriteLine("이미 구매한 아이템입니다.");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    if (Gold >= everyItemGold[Index])
                                    {
                                        buyItemGold[buyCNT] = everyItemGold[Index];
                                        buyItemCHK[Index] = true;
                                        possessionItem[buyCNT] = everyItem[Index];
                                        Gold -= everyItemGold[Index];
                                        for (int i = 0; i < 2; i++)
                                        {
                                            MyStats[buyCNT, i] = ItemStats[Index, i];
                                        }
                                        Console.WriteLine("구매를 완료했습니다.");
                                        Console.ReadKey();
                                        buyCNT++;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Gold가 부족합니다.");
                                        Console.ReadKey();
                                    }
                                }
                            }
                            else if (Index == -1)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("잘못된 입력입니다.");
                                Console.ReadKey();
                            }
                        }
                    }
                    //아이템 판매
                    else if (Choice == 2)
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("상점 - 아이템 구매");
                            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                            Console.WriteLine();
                            Console.WriteLine("[보유 골드]");
                            Console.WriteLine("{0} G", Gold);
                            Console.WriteLine();
                            Console.WriteLine("[아이템 목록");
                            for (int i = 0; i < possessionItem.Length; i++)
                            {
                                if (possessionItem?[i] != null)
                                {
                                    Console.WriteLine("- {0} {1} | {2} G", i + 1, possessionItem[i], buyItemGold[i]);
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine("0. 나가기");
                            Console.WriteLine();
                            Console.WriteLine("원하시는 행동을 입력해주세요");
                            Console.Write(">> ");
                            int Index = int.Parse(Console.ReadLine()) - 1;
                            if (Index < possessionItem.Length && Index > -1)
                            {
                                if (EquippedItem[Index] == true)
                                {
                                    int startIdx = possessionItem[Index].IndexOf("]");
                                    possessionItem[Index] = possessionItem[Index].Substring(startIdx + 1);
                                    AttackPower -= MyStats[Index, 0];
                                    DefensePower -= MyStats[Index, 1];
                                    APP -= MyStats[Index, 0];
                                    DPP -= MyStats[Index, 1];
                                }

                                for (int i = 0; i < everyItem.Length; i++)
                                {
                                    if (possessionItem[Index] == everyItem[i]) buyItemCHK[i] = false;
                                }


                                for (int i = Index; i < buyCNT; i++)
                                {
                                    if (i + 1 == buyCNT)
                                    {
                                        System.Array.Clear(possessionItem, i, 1);
                                        MyStats[buyCNT, 0] = 0;
                                        MyStats[buyCNT, 1] = 0;
                                        break;
                                    }
                                    else
                                    {
                                        possessionItem[i] = possessionItem[i + 1];
                                    }

                                    for (int j = 0; j < 2; j++)
                                    {
                                        MyStats[i, j] = MyStats[i + 1, j];
                                    }
                                }


                                Gold += buyItemGold[Index] / 100 * 85;

                                buyCNT--;
                                EquippedItem[buyCNT] = false;

                                Console.WriteLine("판매를 완료했습니다.");
                                Console.ReadKey();

                            }
                            else if (Index == -1)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("잘못된 입력입니다.");
                                Console.ReadKey();
                            }
                        }
                    }
                    else if (Choice == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("잘못된 입력입니다.", ex.Message);
                    Console.ReadKey();
                }
            }
        }

        // 캐릭터생성 및 직업선택
        static public void NewStart()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
                Console.WriteLine("원하시는 이름을 설정해주세요.");
                Console.WriteLine();
                Name = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("입력하신 이름은 {0} 입니다.", Name);
                Console.WriteLine();
                Console.WriteLine("1. 저장");
                Console.WriteLine("2. 취소");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                try
                {
                    int Choice = int.Parse(Console.ReadLine());
                    if (Choice == 1)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("잘못된 입력입니다.", ex.Message);
                    Console.ReadKey();
                }
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
                Console.WriteLine("원하시는 직업을 선택해주세요.");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 도적");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                try
                {
                    int Choice = int.Parse(Console.ReadLine());
                    if (Choice == 1)
                    {
                        Chad = "전사";
                        break;
                    }
                    else if (Choice == 2)
                    {
                        Chad = "도적";
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("잘못된 입력입니다.", ex.Message);
                    Console.ReadKey();
                }
            }
        }

        //던전
        static public void Dungeon()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("던전입장");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("1. 쉬운 던전 방어력 5 이상 권장");
                Console.WriteLine("2. 일반 던전 방어력 11 이상 권장");
                Console.WriteLine("3. 어려운 던전 방어력 17 이상 권장");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요");
                Console.Write(">> ");
                try
                {
                    int Choice = int.Parse(Console.ReadLine());
                    if (Choice > 0 && Choice < 4)
                    {
                        if (Hp < 0)
                        {
                            Console.WriteLine("체력이 부족하여 던전에 입장하지 못합니다.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Clear(Choice);
                            if (fail)
                            {
                                fail = false;
                                Console.WriteLine();
                                Console.WriteLine("클리어 실패");
                                Console.WriteLine("체력이 감소합니다.");
                                Console.ReadKey();
                            }
                        }
                    }
                    else if (Choice == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("잘못된 입력입니다.", ex.Message);
                    Console.ReadKey();
                }
            }
        }

        //던전클리어
        static public void Clear(int DL)
        {
            Console.Clear();
            string Difficulty;
            Random rand = new Random();
            int Hpdecrease = rand.Next(20, 35);
            int Gdincrease = rand.Next((int)AttackPower, (int)AttackPower * 2);
            if (DL == 1)
            {
                if (DefensePower < 5)
                {
                    int probability = rand.Next(1, 100);
                    if(probability < 41)
                    {
                        Hp -= Hpdecrease / 2;
                        fail =true;
                        return ;
                    }

                }
                Gdincrease = 1000 + 1000 / 100 * Gdincrease;
                Hpdecrease += 5;
                Difficulty = "쉬운"; 
            }
            else if(DL == 2)
            {
                if (DefensePower < 11) 
                {
                    int probability = rand.Next(1, 100);
                    if (probability < 41)
                    {
                        Hp -= Hpdecrease / 2;
                        fail = true;
                        return;
                    }
                }
                Gdincrease = 1700 + 1000 / 100 * Gdincrease;
                Hpdecrease += 11;
                Difficulty = "일반";
            }
            else
            {
                if (DefensePower < 17)
                {
                    int probability = rand.Next(1, 100);
                    if (probability < 41)
                    {
                        Hp -= Hpdecrease / 2;
                        fail = true;
                        return;
                    }
                }
                Gdincrease = 2500 + 1000 / 100 * Gdincrease;
                Hpdecrease += 17;
                Difficulty = "어려운";
            }
            
            Console.WriteLine("던전 클리어");
            Console.WriteLine("축하합니다!!");
            Console.WriteLine("{0} 던전을 클리어 하셨습니다.", Difficulty);
            Console.WriteLine();
            Console.WriteLine("체력 {0} -> {1}", Hp, (Hp -= Hpdecrease - (int)DefensePower));
            Console.WriteLine("Gold {0} G -> {1} G", Gold, Gold += Gdincrease);
            LvUp();
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">> ");
            try{
                int Choice = int.Parse(Console.ReadLine());
                if (Choice != 0)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.WriteLine("던전을 나간다.");
                    Console.ReadKey();
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("잘못된 입력입니다.", ex.Message);
                Console.WriteLine("던전을 나간다.");
                Console.ReadKey();
            }
        }

        //레벨업   
        static public void LvUp()
        {
            claerCount++;
            if (Level == claerCount)
            {
                claerCount = 0;
                AttackPower += 0.5f;
                DefensePower += 1f;
                Console.WriteLine("Lv업 하셨습니다 {0} -> {1}", Level, Level += 1);
            }
        }
        
        // 휴식지
        static public void Rest()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("휴식하기");
                Console.WriteLine("500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {0} G)", Gold);
                Console.WriteLine();
                Console.WriteLine("1. 휴식하기");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요");
                Console.Write(">> ");
                try
                {
                    int Choice = int.Parse(Console.ReadLine());
                    if (Choice == 1)
                    {
                        if (Gold >= 500)
                        {
                            Hp = 100;
                            Gold -= 500;
                            Console.WriteLine("휴식을 완료했습니다.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Gold가 부족합니다.");
                            Console.ReadKey();
                        }
                    }
                    else if (Choice == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("잘못된 입력입니다.", ex.Message);
                    Console.ReadKey();
                }
            }
        }

        //장착 메소드
        static public void Equipped(int Index)
        {
            possessionItem[Index] = "[E]" + possessionItem[Index];
            EquippedItem[Index] = true;
            AttackPower += MyStats[Index, 0];
            DefensePower += MyStats[Index, 1];
            APP += MyStats[Index, 0];
            DPP += MyStats[Index, 1];
        }


        //해제 메소드
        static public void Release(int Index)
        {
            int startIdx = possessionItem[Index].IndexOf("]");
            possessionItem[Index] = possessionItem[Index].Substring(startIdx + 1);
            EquippedItem[Index] = false;
            AttackPower -= MyStats[Index, 0];
            DefensePower -= MyStats[Index, 1];
            APP -= MyStats[Index, 0];
            DPP -= MyStats[Index, 1];
        }

        
    }
}

