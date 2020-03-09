using System;
using System.Collections.Generic;

namespace Miniprojekt___Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<MenuItem> items = new List<MenuItem>();
            Menu menu = new Menu("Menu1");
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
        public int SelectedItemId { get; set; }
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

            int i = 0;

            foreach (MenuItem item in items)
            {
                if (Index == i)
                {
                    Console.BackgroundColor = ConsoleColor.White;
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
                    handler.Select();
                    break;
                default:
                    break;
            }
        }

        public void Start()
        {
            running = true;
            do
            {
                Console.Clear();
                DrawMenu();
                HandleInput();
                
            } while (running == true);
            
            
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

        public void Select()
        {

        }
    }

    public class InputHandler
    {
        public void MoveUp(Menu menu)
        {
            if (menu.Index >= 0)
            {
                menu.Index -= 1;
            } else
            {
                menu.Index = menu.Items.Count - 1;
            }
                
        }

        public void MoveDown(Menu menu)
        {
            if (menu.Index <= menu.Items.Count - 1)
            {
                menu.Index += 1;
            } else
            {
                menu.Index = 0;
            }
            
        }

        public void Select()
        {
            // ...
        }
    }
}
