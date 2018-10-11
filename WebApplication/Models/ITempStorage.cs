namespace WebApplication.Models
{
    public interface ITempStorage<TForm>
    {
        TForm Get(int formId);

        void Set(int formId, TForm form);

        bool Contains(int formId);

        void Clear(int formId);
    }
}