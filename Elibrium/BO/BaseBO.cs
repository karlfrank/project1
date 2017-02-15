namespace Elibrium.BO
{
    public class BaseBO
    {
        public int _id;

        public int Id
        {
            get
            {
                return this._id;
            }
        }
        protected bool _isNew
        {
            get { return _id < 1; }
        }
    }
}
