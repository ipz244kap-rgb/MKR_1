using System.Text;

namespace StructuralPatternsLab
{
    public class State_VisibleState : State_INodeState
    {
        public string Render(Composite_LightElementNode node)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<{node.TagName}");

            if (node.CssClasses.Count > 0)
            {
                sb.Append($" class=\"{string.Join(" ", node.CssClasses)}\"");
            }

            if (node.Closing == ClosingType.Single)
            {
                sb.Append(" />");
            }
            else
            {
                sb.Append(">");
                sb.Append(node.InnerHTML);
                sb.Append($"</{node.TagName}>");
            }

            return sb.ToString();
        }
    }
}
