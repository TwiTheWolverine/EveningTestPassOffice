namespace PassOffice.EF.Dto;

public class PassDto
{
	public int UserId { get; set; }

	public PassStatusEnum Status { get; set; }
	public PassTypeEnum Type { get; set; }

	public DateTime IssueDate { get; set; }
	public DateTime ValidFrom { get; set; }
	public DateTime? ValidTo { get; set; }
}