﻿namespace PassOffice.EF.Entity;

public class User
{
	public int Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string? MiddleName { get; set; }
	public string? Description { get; set; }
}