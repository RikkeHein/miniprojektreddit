using System;
namespace miniprojektreddit.Model
{
	public class Vote
	{
		public Vote(bool votes)
		{
			this.Votes = votes;
		}

		public Vote()
		{

		}

		public bool Votes { get; set; }
	}

}

