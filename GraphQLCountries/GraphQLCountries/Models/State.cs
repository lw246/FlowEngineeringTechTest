﻿namespace GraphQLCountries.Models
{
	public class State
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public Country Country { get; set; }
	}
}
