namespace CourseManagement.Service.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
            return;
        }
    }
}
