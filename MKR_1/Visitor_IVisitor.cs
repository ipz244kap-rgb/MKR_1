namespace StructuralPatternsLab
{
    public interface Visitor_IVisitor
    {
        void VisitElement(Template_Composite_LightElementNode element);
        void VisitText(Template_Composite_LightTextNode text);
    }
}
