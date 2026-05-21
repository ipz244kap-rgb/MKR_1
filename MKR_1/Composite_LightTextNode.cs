namespace StructuralPatternsLab
{
    public class Composite_LightTextNode : Composite_LightNode
    {
        private string _text;

        public Composite_LightTextNode(string text)
        {
            _text = text;
        }

        public override string OuterHTML => _text;
        public override string InnerHTML => _text;
    }
}
