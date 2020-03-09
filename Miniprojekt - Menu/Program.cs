using System;
using System.Collections.Generic;

namespace Miniprojekt___Menu
{
    class Program
    {
        static void Main(string[] args)
        {
   
            Menu menu = new Menu("Fancy Menu");
            menu.AddMenuItem(new MenuItem("Item 1", "Content of item 1"));
            menu.AddMenuItem(new MenuItem("Item 2", "Content of item 2"));
            menu.AddMenuItem(new MenuItem("Item 3", "Content of item 3"));
            menu.AddMenuItem(new MenuItem("Item 4", "Content of item 4"));
            menu.AddMenuItem(new MenuItem("Item 5", "Content of item 5"));
            menu.AddMenuItem(new MenuItem("Item 6", "Content of item 6"));
            menu.Start();
        }
    }

    public class Menu
    {
        public int Index { get; set; }

        public bool running { get; set; }
        public string MenuTitle { get; set; }
        private List<MenuItem> items = new List<MenuItem>();

        public List<MenuItem> Items
        {
            get { return items; }
        }

        public Menu(string title)
        {
            MenuTitle = title;
            Index = 0;
            running = false;
        }

        public void AddMenuItem(MenuItem item)
        {
            Items.Add(item);
        }

        public void DrawMenu()
        {
            Console.SetCursorPosition((Console.WindowWidth - MenuTitle.Length) / 2, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{MenuTitle}");

            Console.WriteLine("");

            int i = 0;
            foreach (MenuItem item in items)
            {
                Console.SetCursorPosition((Console.WindowWidth - item.Title.Length) / 2, Console.CursorTop);
                Console.ForegroundColor = ConsoleColor.White;

                if (Index == i)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"{item.Title}");
                } else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine($"{item.Title}");
                }
                i++;
            }

            //Console.WriteLine(Index);
        }

        public void HandleInput()
        {
            InputHandler handler = new InputHandler();

            ConsoleKeyInfo cki = Console.ReadKey();
            switch(cki.Key)
            {
                case ConsoleKey.Backspace:
                case ConsoleKey.Escape:
                    running = false;
                    break;
                case ConsoleKey.UpArrow:
                    handler.MoveUp(this);
                    break;
                case ConsoleKey.DownArrow:
                    handler.MoveDown(this);
                    break;
                case ConsoleKey.Enter:
                    handler.Select(Items[Index]);
                    break;
                default:
                    break;
            }
        }

        public void Start()
        {
            DrawMenu();
            running = true;
            while(running == true) {
                HandleInput();
            };
            
            
        }
    }

    public class MenuItem
    {
        public string Content { get; set; }
        public string Title { get; set; }

        public MenuItem(string title, string content)
        {
            Title = title;
            Content = content;
        }

    }

    

    public class InputHandler
    {
        public void MoveUp(Menu menu)
        {
            Console.Clear();
            if (menu.Index >= 0)
            {
                menu.Index -= 1;
            } else
            {
                menu.Index = menu.Items.Count - 1;
            }
            menu.DrawMenu();
        }

        public void MoveDown(Menu menu)
        {
            Console.Clear();
            if (menu.Index <= menu.Items.Count - 1)
            {
                menu.Index += 1;
            } else
            {
                menu.Index = 0;
            }
            menu.DrawMenu();
        }

        public void Select(MenuItem item)
        {
            Console.WriteLine("");
            Console.SetCursorPosition((Console.WindowWidth - item.Content.Length) / 2, Console.CursorTop);
            
            Console.WriteLine($"{item.Content}");
            

        }
    }
}
