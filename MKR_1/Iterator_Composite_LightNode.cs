using System.Collections.Generic;

namespace StructuralPatternsLab
{
    public class Iterator_Composite_LightNode
    {
        private Stack<Template_Composite_LightNode> _stack = new Stack<Template_Composite_LightNode>();

        public Iterator_Composite_LightNode(Template_Composite_LightNode node)
        {
            _stack.Push(node);
        }

        public bool HasNext()
        {
            return _stack.Count > 0;
        }

        public Template_Composite_LightNode? Next()
        {
            if (!HasNext())
            {
                return null;
            }

            var current = _stack.Pop();

            if (current is Template_Composite_LightElementNode element)
            {
                var children = element.GetChildren();
                for (int i = children.Count - 1; i >= 0; i--)
                {
                    _stack.Push(children[i]);
                }
            }

            return current;
        }
    }
}
