using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

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
            "키보드 | 공격력 + 10 | 방어력 + 10 | 코딩 필수템" };
        static string[] possessionItem = new string[7];
        static bool[] EquippedItem = { false, false, false, false, false, false, false };
        static int[] everyItemGold = { 1000, 1800, 3500, 600, 1500, 2700, 5000 };
        static int[] buyItemGold = new int[7];
        static bool[] buyItemCHK = { false, false, false, false, false, false, false };

        static int[,] ItemStats = new int[7, 2] { { 0, 5 }, { 0, 9 }, { 0, 15 }, { 2, 0 }, { 5, 0 }, { 7, 0 }, { 10, 10 } };
        static int[,] MyStats = new int[7, 2];

        static int Level = 01;
        static string Name;
        static string Chad;
        static int AttackPower = 10;
        static int defensePower = 5;
        static int Hp = 100;
        static int Gold = 50000;
        static int buyCNT = 0;
        static int EquippedCNT = 0;
        static int APP = 0;
        static int DPP = 0;

        static void Main(string[] args)
        {
            //NewStart();
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
                    Console.WriteLine("방어력 :  {0}(+{1})", defensePower, DPP);
                }
                else
                {
                    Console.WriteLine("방어력 :  {0}", defensePower);
                }
                Console.WriteLine("체 력 :  {0}", Hp);
                Console.WriteLine("Gold :  {0} G", Gold);
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
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
                            if (EquippedItem[Index] == false)
                            {
                                possessionItem[Index] = "[E]" + possessionItem[Index];
                                EquippedItem[Index] = true;
                                AttackPower += MyStats[Index, 0];
                                defensePower += MyStats[Index, 1];
                                APP += MyStats[Index, 0];
                                DPP += MyStats[Index, 1];
                                EquippedCNT++;

                            }
                            else
                            {
                                int startIdx = possessionItem[Index].IndexOf("]");
                                possessionItem[Index] = possessionItem[Index].Substring(startIdx + 1);
                                EquippedItem[Index] = false;
                                AttackPower -= MyStats[Index, 0];
                                defensePower -= MyStats[Index, 1];
                                APP -= MyStats[Index, 0];
                                DPP -= MyStats[Index, 1];
                                EquippedCNT--;
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
                        if (Index <= possessionItem.Length && Index >= 0)
                        {
                            Array.Clear(possessionItem, Index, 0);
                            buyItemCHK[Index] = false;
                            Gold -= everyItemGold[Index];
                            for (int i = 0; i < 2; i++)
                            {
                                int tep = ItemStats[buyCNT, i];
                                ItemStats[buyCNT, i] = ItemStats[Index, i];
                                ItemStats[Index, i] = tep;
                            }
                            Console.WriteLine("판매를 완료했습니다.");
                            Console.ReadKey();
                            buyCNT++;
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
        }

        // 휴식
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
        }
    }
}

