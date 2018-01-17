using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreehouseDefense
{

	[Serializable]
	public class TreehouseDefenseException : Exception
	{
		public TreehouseDefenseException() { }
		public TreehouseDefenseException(string message) : base(message) { }
		public TreehouseDefenseException(string message, Exception inner) : base(message, inner) { }
		protected TreehouseDefenseException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}

	[Serializable]
	public class OutOfBoundsException : TreehouseDefenseException
	{
		public OutOfBoundsException() { }
		public OutOfBoundsException(string message) : base(message) { }
		public OutOfBoundsException(string message, Exception inner) : base(message, inner) { }
		protected OutOfBoundsException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
