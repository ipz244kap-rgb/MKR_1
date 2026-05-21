namespace StructuralPatternsLab
{
    public abstract class Composite_LightNode
    {
        public abstract string OuterHTML { get; }
        public abstract string InnerHTML { get; }

        public Iterator_Composite_LightNode GetIterator()
        {
            return new Iterator_Composite_LightNode(this);
        }
    }
}
