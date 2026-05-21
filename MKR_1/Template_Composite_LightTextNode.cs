namespace StructuralPatternsLab
{
    public class Template_Composite_LightTextNode : Template_Composite_LightNode
    {
        private string _text;

        public Template_Composite_LightTextNode(string text)
        {
            _text = text;
        }

        public override string OuterHTML => Render();
        public override string InnerHTML => _text;

        protected override string GetOpeningTag() => "";
        protected override string GetContent() => _text;
        protected override string GetClosingTag() => "";
    }
}
