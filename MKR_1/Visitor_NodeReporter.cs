using System;

namespace StructuralPatternsLab
{
    public class Visitor_NodeReporter : Visitor_IVisitor
    {
        public void VisitElement(Template_Composite_LightElementNode element)
        {
            Console.WriteLine($"Visitor: Елемент <{element.TagName}> з {element.ChildrenCount} дочірніми вузлами.");
        }

        public void VisitText(Template_Composite_LightTextNode text)
        {
            Console.WriteLine($"Visitor: Текстовий вузол довжиною {text.InnerHTML.Length} символів.");
        }
    }
}
