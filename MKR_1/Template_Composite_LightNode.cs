namespace StructuralPatternsLab
{
    public abstract class Template_Composite_LightNode
    {
        public string Render()
        {
            return GetOpeningTag() + GetContent() + GetClosingTag();
        }

        protected abstract string GetOpeningTag();
        protected abstract string GetContent();
        protected abstract string GetClosingTag();

        public abstract string OuterHTML { get; }
        public abstract string InnerHTML { get; }

        public Iterator_Composite_LightNode GetIterator()
        {
            return new Iterator_Composite_LightNode(this);
        }
    }
}
