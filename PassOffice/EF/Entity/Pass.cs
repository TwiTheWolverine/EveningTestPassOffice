using PassOffice.EF.Dto;

namespace PassOffice.EF.Entity;

public class Pass
{
	public int Id { get; set; }
	public int UserId { get; set; }
	
	public PassStatusEnum  Status { get; set; }
	public PassTypeEnum Type { get; set; }

	public DateTime IssueDate { get; set; }
	public DateTime ValidFrom { get; set; }
	public DateTime? ValidTo { get; set; }

	public virtual User User { get; set; }
}