using System.Text;

namespace StructuralPatternsLab
{
    public class State_VisibleState : State_INodeState
    {
        public string Render(Template_Composite_LightElementNode node)
        {
            return node.Render();
        }
    }
}
