using System.Collections.Generic;
using System.Text;

namespace StructuralPatternsLab
{
    public class Template_Composite_LightElementNode : Template_Composite_LightNode
    {
        public string TagName { get; }
        public DisplayType Display { get; }
        public ClosingType Closing { get; }
        public List<string> CssClasses { get; }
        private List<Template_Composite_LightNode> _children;
        private State_INodeState _state;

        public Template_Composite_LightElementNode(string tagName, DisplayType displayType, ClosingType closingType,
            List<string> cssClasses)
        {
            TagName = tagName;
            Display = displayType;
            Closing = closingType;
            CssClasses = cssClasses ?? new List<string>();
            _children = new List<Template_Composite_LightNode>();
            _state = new State_VisibleState();
        }

        public void SetState(State_INodeState state)
        {
            _state = state;
        }

        public List<Template_Composite_LightNode> GetChildren()
        {
            return _children;
        }

        public int ChildrenCount => _children.Count;

        public void Add(Template_Composite_LightNode node)
        {
            _children.Add(node);
        }

        public void Remove(Template_Composite_LightNode node)
        {
            _children.Remove(node);
        }

        public override string InnerHTML => GetContent();

        public override string OuterHTML => _state.Render(this);

        public override void Accept(Visitor_IVisitor visitor)
        {
            visitor.VisitElement(this);
        }

        protected override string GetOpeningTag()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<{TagName}");
            if (CssClasses.Count > 0)
            {
                sb.Append($" class=\"{string.Join(" ", CssClasses)}\"");
            }
            if (Closing == ClosingType.Single)
            {
                sb.Append(" />");
            }
            else
            {
                sb.Append(">");
            }
            return sb.ToString();
        }

        protected override string GetContent()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var child in _children)
            {
                sb.Append(child.OuterHTML);
            }
            return sb.ToString();
        }

        protected override string GetClosingTag()
        {
            if (Closing == ClosingType.Paired)
            {
                return $"</{TagName}>";
            }
            return "";
        }
    }
}
