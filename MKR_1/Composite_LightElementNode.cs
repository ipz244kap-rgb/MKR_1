using System.Collections.Generic;
using System.Text;

namespace StructuralPatternsLab
{
    public class Composite_LightElementNode : Composite_LightNode
    {
        public string TagName { get; }
        public DisplayType Display { get; }
        public ClosingType Closing { get; }
        public List<string> CssClasses { get; }
        private List<Composite_LightNode> _children;
        private State_INodeState _state;

        public Composite_LightElementNode(string tagName, DisplayType displayType, ClosingType closingType,
            List<string> cssClasses)
        {
            TagName = tagName;
            Display = displayType;
            Closing = closingType;
            CssClasses = cssClasses ?? new List<string>();
            _children = new List<Composite_LightNode>();
            _state = new State_VisibleState();
        }

        public void SetState(State_INodeState state)
        {
            _state = state;
        }

        public List<Composite_LightNode> GetChildren()
        {
            return _children;
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

        public override string OuterHTML => _state.Render(this);
    }
}
