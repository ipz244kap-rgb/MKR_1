using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralPatternsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Template_Composite_LightElementNode ul = new Template_Composite_LightElementNode("ul", DisplayType.Block, ClosingType.Paired,
                new List<string> { "list-group" });

            Template_Composite_LightElementNode li1 = new Template_Composite_LightElementNode("li", DisplayType.Block, ClosingType.Paired,
                new List<string> { "list-group-item" });
            li1.Add(new Template_Composite_LightTextNode("Перший елемент списку"));

            Template_Composite_LightElementNode li2 = new Template_Composite_LightElementNode("li", DisplayType.Block, ClosingType.Paired,
                new List<string> { "list-group-item" });
            li2.Add(new Template_Composite_LightTextNode("Другий елемент списку"));

            Template_Composite_LightElementNode img = new Template_Composite_LightElementNode("img", DisplayType.Inline,
                ClosingType.Single, new List<string> { "list-icon" });
            li2.Add(img);

            ul.Add(li1);
            ul.Add(li2);

            Console.WriteLine("OuterHTML:");
            Console.WriteLine(ul.OuterHTML);

            Console.WriteLine("\nInnerHTML:");
            Console.WriteLine(ul.InnerHTML);

            Console.WriteLine($"\nКількість дочірніх елементів у <ul>: {ul.ChildrenCount}");
            Console.WriteLine($"Кількість дочірніх елементів у другому <li>: {li2.ChildrenCount}");

            Console.WriteLine("\nОбхід дерева за допомогою ітератора:");
            var iterator = ul.GetIterator();
            while (iterator.HasNext())
            {
                var node = iterator.Next();
                if (node is Template_Composite_LightElementNode el)
                {
                    Console.WriteLine($"Елемент: <{el.TagName}>");
                }
                else if (node is Template_Composite_LightTextNode text)
                {
                    Console.WriteLine($"Текст: {text.InnerHTML}");
                }
            }

            Console.WriteLine("\n--- Тестування Command ---");
            Command_Invoker invoker = new Command_Invoker();
            
            Template_Composite_LightElementNode li3 = new Template_Composite_LightElementNode("li", DisplayType.Block, ClosingType.Paired,
                new List<string> { "list-group-item" });
            li3.Add(new Template_Composite_LightTextNode("Третій елемент (доданий через Command)"));

            Command_AddNode addCommand = new Command_AddNode(ul, li3);
            
            Console.WriteLine($"Кількість елементів перед виконанням команди: {ul.ChildrenCount}");
            invoker.ExecuteCommand(addCommand);
            Console.WriteLine($"Кількість елементів після виконання команди: {ul.ChildrenCount}");
            
            invoker.Undo();
            Console.WriteLine($"Кількість елементів після Undo: {ul.ChildrenCount}");

            Console.WriteLine("\n--- Тестування State ---");
            Console.WriteLine("Поточний стан: Visible");
            Console.WriteLine($"Результат рендерингу li1: {li1.OuterHTML}");

            li1.SetState(new State_HiddenState());
            Console.WriteLine("Поточний стан: Hidden");
            Console.WriteLine($"Результат рендерингу li1: {li1.OuterHTML} (порожньо)");

            li1.SetState(new State_VisibleState());
            Console.WriteLine("Поточний стан: Visible");
            Console.WriteLine($"Результат рендерингу li1: {li1.OuterHTML}");

            Console.WriteLine("\n--- Тестування Visitor ---");
            Visitor_NodeReporter reporter = new Visitor_NodeReporter();
            var visitIterator = ul.GetIterator();
            while (visitIterator.HasNext())
            {
                var node = visitIterator.Next();
                node?.Accept(reporter);
            }
        }
    }
}
