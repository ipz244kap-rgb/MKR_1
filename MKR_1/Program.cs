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

            Composite_LightElementNode ul = new Composite_LightElementNode("ul", DisplayType.Block, ClosingType.Paired,
                new List<string> { "list-group" });

            Composite_LightElementNode li1 = new Composite_LightElementNode("li", DisplayType.Block, ClosingType.Paired,
                new List<string> { "list-group-item" });
            li1.Add(new Composite_LightTextNode("Перший елемент списку"));

            Composite_LightElementNode li2 = new Composite_LightElementNode("li", DisplayType.Block, ClosingType.Paired,
                new List<string> { "list-group-item" });
            li2.Add(new Composite_LightTextNode("Другий елемент списку"));

            Composite_LightElementNode img = new Composite_LightElementNode("img", DisplayType.Inline,
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
                if (node is Composite_LightElementNode el)
                {
                    Console.WriteLine($"Елемент: <{el.OuterHTML.Substring(1, el.OuterHTML.IndexOfAny(new char[] { ' ', '>', '/' }) - 1)}>");
                }
                else if (node is Composite_LightTextNode text)
                {
                    Console.WriteLine($"Текст: {text.InnerHTML}");
                }
            }
        }
    }
}
