using System.Web;
using System.Web.SessionState;
using WebApplication.Forms.Courses;

namespace WebApplication.Models
{
    public class SessionEditCourseFormTempStorage : IFormTempStorage<EditCourseForm>
    {
        private const string EditFormKeyPrefix = "EditCourseForm_";

        private readonly HttpSessionState _session;

        public SessionEditCourseFormTempStorage()
        {
            _session = HttpContext.Current.Session;
        }

        public EditCourseForm Get(int formId)
        {
            return _session[EditFormKeyPrefix + formId] as EditCourseForm;
        }

        public void Set(int formId, EditCourseForm form)
        {
            _session[EditFormKeyPrefix + formId] = form;
        }

        public bool Contains(int formId)
        {
            return _session[EditFormKeyPrefix + formId] != null;
        }

        public void Clear(int formId)
        {
            _session[EditFormKeyPrefix + formId] = null;
        }
    }
}