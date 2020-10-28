using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_1.Business
{
    
    public abstract class Menu
    {
        private string[] mn;
        public Menu(string[] mn)
        {
            this.mn = mn;
        }
        public int MaxMuc()
        {
            int max = mn[0].Length;
            for (int i = 1; i < mn.Length; ++i)
                if (max < mn[i].Length)
                    max = mn[i].Length;
            return max;
        }
        public void ChuanHoaMenu()
        {
            int max = MaxMuc();
            for (int i = 0; i < mn.Length; ++i)
                mn[i] = Demo.Utility.CongCu.ChuanHoaXau(mn[i], max);
        }
        public void Writexy(int x, int y, int vitri, ConsoleColor maunen, ConsoleColor mauchu)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = maunen;
            Console.ForegroundColor = mauchu;
            Console.Write(mn[vitri]);
        }
        public void Writexy(int x, int y, string s)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }
        public void HienMeNu(int x, int y, ConsoleColor maunen_t, ConsoleColor mauchu_t, ConsoleColor maunen_s, ConsoleColor mauchu_s)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            ChuanHoaMenu();
            int chon = 0;
            for (int i = 0; i < mn.Length; ++i) Writexy(x, y + i, i, maunen_t, mauchu_t);
            Writexy(x, y + chon, chon, maunen_s, mauchu_s);
            do
            {
                ConsoleKeyInfo kt = Console.ReadKey();
                for (int i = 0; i < mn.Length; ++i) Writexy(x, y + i, i, maunen_t, mauchu_t);
                switch (kt.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (chon == mn.Length - 1) chon = 0;
                        else chon = chon + 1;
                        Writexy(x, y + chon, chon, maunen_s, mauchu_s);
                        break;
                    case ConsoleKey.UpArrow:
                        if (chon == 0) chon = mn.Length - 1;
                        else chon = chon - 1;
                        Writexy(x, y + chon, chon, maunen_s, mauchu_s);
                        break;
                    case ConsoleKey.Enter:
                        ThucHien(chon);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        for (int i = 0; i < mn.Length; ++i) Writexy(x, y + i, i, maunen_t, mauchu_t);
                        Writexy(x, y + chon, chon, maunen_s, mauchu_s);
                        break;
                }
                Writexy(x, y + mn.Length + 1, "Ban dang chon muc:" + chon);
            } while (true);
        }
        public abstract void ThucHien(int vitri);
    }
}
