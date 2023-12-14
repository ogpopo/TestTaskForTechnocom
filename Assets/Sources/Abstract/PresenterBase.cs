public class PresenterBase<T1, T2> where T1 : IModel where T2 : IView
{
    protected T1 Model { get; private set; }
    protected T2 View { get; private set; }

    public PresenterBase(T1 model, T2 view)
    {
        Model = model;
        View = view;
    }
}