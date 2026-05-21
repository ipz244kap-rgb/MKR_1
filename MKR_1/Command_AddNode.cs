namespace StructuralPatternsLab
{
    public class Command_AddNode : Command_ICommand
    {
        private Composite_LightElementNode _parent;
        private Composite_LightNode _child;

        public Command_AddNode(Composite_LightElementNode parent, Composite_LightNode child)
        {
            _parent = parent;
            _child = child;
        }

        public void Execute()
        {
            _parent.Add(_child);
        }

        public void Undo()
        {
            _parent.Remove(_child);
        }
    }
}
