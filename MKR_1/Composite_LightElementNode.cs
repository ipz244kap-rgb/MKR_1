using System.Collections.Generic;
using System.Text;

namespace StructuralPatternsLab
{
    public class Composite_LightElementNode : Composite_LightNode
    {
        private string _tagName;
        private DisplayType _displayType;
        private ClosingType _closingType;
        private List<string> _cssClasses;
        private List<Composite_LightNode> _children;

        public Composite_LightElementNode(string tagName, DisplayType displayType, ClosingType closingType,
            List<string> cssClasses)
        {
            _tagName = tagName;
            _displayType = displayType;
            _closingType = closingType;
            _cssClasses = cssClasses ?? new List<string>();
            _children = new List<Composite_LightNode>();
        }

        public int ChildrenCount => _children.Count;

        public void Add(Composite_LightNode node)
        {
            _children.Add(node);
        }

        public void Remove(Composite_LightNode node)
        {
            _children.Remove(node);
        }

        public override string InnerHTML
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var child in _children)
                {
                    sb.Append(child.OuterHTML);
                }
                return sb.ToString();
            }
        }

        public override string OuterHTML
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"<{_tagName}");

                if (_cssClasses.Count > 0)
                {

                    sb.Append($" class=\"{string.Join(" ", _cssClasses)}\"");
                }

                if (_closingType == ClosingType.Single)
                {
                    sb.Append(" />");
                }
                else
                {
                    sb.Append(">");
                    sb.Append(InnerHTML);
                    sb.Append($"</{_tagName}>");
                }

                return sb.ToString();
            }
        }
    }
}
