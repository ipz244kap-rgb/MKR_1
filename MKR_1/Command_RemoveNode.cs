namespace StructuralPatternsLab
{
    public class Command_RemoveNode : Command_ICommand
    {
        private Template_Composite_LightElementNode _parent;
        private Template_Composite_LightNode _child;

        public Command_RemoveNode(Template_Composite_LightElementNode parent, Template_Composite_LightNode child)
        {
            _parent = parent;
            _child = child;
        }

        public void Execute()
        {
            _parent.Remove(_child);
        }

        public void Undo()
        {
            _parent.Add(_child);
        }
    }
}
