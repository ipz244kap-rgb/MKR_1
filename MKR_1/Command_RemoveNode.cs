namespace StructuralPatternsLab
{
    public class Command_RemoveNode : Command_ICommand
    {
        private Composite_LightElementNode _parent;
        private Composite_LightNode _child;

        public Command_RemoveNode(Composite_LightElementNode parent, Composite_LightNode child)
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
