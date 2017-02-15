using System;
using System.Text;

namespace Elibrium.BO
{
	public class BaseTypeBO : BaseBO
	{
		public string _name { get; set; }
		public string Name
		{
			get
			{
				return this._name;
			}
		}

		override
        public String ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(_id + " ").Append(_name);
			return sb.ToString();
		}
	}
}
